using UnityEngine;
using UnityEngine.UI;

public class ZonaFinal : MonoBehaviour {

	int CantOrcosActual;
	public Text FinDelJuego;
	static Puerta puerta;

	void Start() {
		puerta = GameObject.FindGameObjectWithTag("Puerta").GetComponent<Puerta>();
	}

	public void ComprobarColision(GameObject g) {
		if(g.GetComponent<IAOrco>().HaceFuerzaContraLaPuerta) {
			IncrementarCantOrcos(g);
			ComprobarFinDelJuego();
		}
	}

	public void OrcoMuerto(IAOrco Orco) {
		if(Orco.HaceFuerzaContraLaPuerta) {
			CantOrcosActual--;
			Debug.Log(CantOrcosActual + "/" + puerta.AguanteMaximo);
			ComprobarFinDelJuego();
		}
	}

	void ComprobarFinDelJuego() {
		if (CantOrcosActual >= puerta.AguanteMaximo) {
			FinDelJuego.gameObject.SetActive(true);
		}
	}

	public void IncrementarCantOrcos(GameObject g) {
		if(g.GetComponent<IAOrco>().HaceFuerzaContraLaPuerta) {
			CantOrcosActual++;
			Debug.Log(CantOrcosActual + "/" + puerta.AguanteMaximo);
			ComprobarFinDelJuego();
		}
	}
		
}
