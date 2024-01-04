using UnityEngine;
using UnityEngine.UI;

public class Puerta : MonoBehaviour {

	public Text FinDelJuego;
	public Text AguanteDePuerta;
	ZonaFinal zonaFinal;
	public int AguanteMaximo;
	int cantOrcosActual;
	public GameObject explosion;

	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "Bala") {
			AguanteMaximo--;
			Instantiate(explosion).GetComponent<Transform>().position = c.transform.position;
			Destroy(c.gameObject);
		}
	}

	public void OrcoMuerto() {
		if(cantOrcosActual-1 >= 0) {
			cantOrcosActual--;
		}
	}

	public void ChequeaFin(int cant) {
		if(cant >= AguanteMaximo) {
			FinDelJuego.text = "Se Termino :d";
		}
		cantOrcosActual = cant;
	}

	void FixedUpdate() {
		AguanteDePuerta.text = cantOrcosActual + "/" + AguanteMaximo;
	}

}
