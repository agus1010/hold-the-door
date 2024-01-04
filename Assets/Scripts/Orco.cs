using UnityEngine;
using Utiles;

public class Orco : MonoBehaviour {

	Rigidbody2D CuerpoRigido;
	GameObject ChocadoPor;
	public int NumeroDeOrco;
	int PosEnCadena;

	Puerta puerta;

	public int DelayDeSegundaSalida;
	Delay delayDeSalida;
	
	bool HaChocado;

	static int numeroDeOrcos;
	
	public float FuerzaDeSalida;

	void Start() {
		NumeroDeOrco = numeroDeOrcos++;
		CuerpoRigido = GetComponent<Rigidbody2D>();
		HaChocado = false;
		delayDeSalida = gameObject.AddComponent<Delay>();
		delayDeSalida.Total = 0;
		PosEnCadena = -1;
		puerta = GameObject.FindGameObjectWithTag("Puerta").GetComponent<Puerta>();
		Mover();
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Orco" || c.gameObject.tag == "Puerta") {
			CuerpoRigido.velocity = new Vector2();
			if(c.contacts[0].point.x < GetComponent<Transform>().position.x) {
				CuerpoRigido.bodyType = RigidbodyType2D.Kinematic;
				if (!HaChocado) {
					HaChocado = !HaChocado;
					delayDeSalida = null;
				}
				if(c.gameObject.tag == "Puerta") {
					PosEnCadena = 1;
				} else {
					PosEnCadena = c.gameObject.GetComponent<Orco>().PosEnCadena + 1;
				}
				puerta.ChequeaFin(PosEnCadena);
			} else {
				ChocadoPor = c.gameObject;
			}
		}
	}

	void FixedUpdate() {
		if(delayDeSalida != null) {
			CuerpoRigido.velocity = new Vector2();
			if(delayDeSalida.LuzVerde) {
				Mover();
			}
		}
	}

	public void Mover() {
		if(HaChocado && delayDeSalida == null) {
			delayDeSalida = gameObject.AddComponent<Delay>();
			delayDeSalida.Total = DelayDeSegundaSalida;
		}
		if (delayDeSalida.LuzVerde) {
			CuerpoRigido.bodyType = RigidbodyType2D.Dynamic;
			CuerpoRigido.AddForce(new Vector2(-FuerzaDeSalida, 0f));
			MoverAnterior();
			delayDeSalida = null;
		}
	}

	void MoverAnterior() {
		if(ChocadoPor != null) {
			ChocadoPor.GetComponent<Orco>().Mover();
			ChocadoPor = null;
		}
	}

	public void Morir() {
		gameObject.SetActive(false);
		MoverAnterior();
		puerta.OrcoMuerto();  //Ultima linea agregada
		Destroy(gameObject);
    }

}
