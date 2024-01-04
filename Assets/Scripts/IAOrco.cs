using UnityEngine;

public class IAOrco : MonoBehaviour {

	static ZonaFinal zonaFinal;
	Rigidbody2D CuerpoRigido;
	GameObject ZonaFinal;
    public float FuerzaDeSalida;
	bool ChocoContraOrcoOPuerta;
	bool EstaEnLaZonaFinal;
	public bool HaceFuerzaContraLaPuerta {
		get {
			return ChocoContraOrcoOPuerta && EstaEnLaZonaFinal;
		}
	}
	public bool FueContado;

	void Start() {
		CuerpoRigido = GetComponent<Rigidbody2D>();
		CuerpoRigido.AddForce(new Vector2(-1 * FuerzaDeSalida, 0f));
		zonaFinal = GameObject.Find("ZonaFinal").GetComponent<ZonaFinal>();
		FueContado = false;
	}
    
	void OnCollisionEnter2D(Collision2D c) {
		if(!ChocoContraOrcoOPuerta && (c.gameObject.tag == "Puerta" || c.gameObject.tag == "Orco")) {
			ChocoContraOrcoOPuerta = true;
			if (!FueContado) {
				FueContado = !FueContado;
				zonaFinal.ComprobarColision(gameObject);
			}
		}
	}

	void OnCollisionExit2D(Collision2D c) {
		if(ChocoContraOrcoOPuerta && (c.gameObject.tag == "Puerta" || c.gameObject.tag == "Orco")) {
			ChocoContraOrcoOPuerta = false;
			if (!FueContado) {
				FueContado = !FueContado;
				zonaFinal.OrcoMuerto(this);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		if(c.tag == "GameController") {
			EstaEnLaZonaFinal = true;
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		if(c.tag == "GameController") {
			EstaEnLaZonaFinal = false;
		}
	}

	public void Morir() {
		zonaFinal.SendMessage("OrcoMuerto",this);
		Destroy(gameObject);
	}

}