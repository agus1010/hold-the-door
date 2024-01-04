using UnityEngine;
using UnityEngine.UI;

public class Arquero : MonoBehaviour {

	public int RetardoDisparo;
	int cooldown;
	public Text UICooldown;

	public GameObject flecha;
	public float FuerzaMaxima;

	LineRenderer trazada;

	void Start() {
		if (RetardoDisparo == 0) {
			RetardoDisparo = 1;
		}
		cooldown = 0;
		trazada = GetComponent<LineRenderer>();
		trazada.useWorldSpace = true;
		//Cursor.visible = false;
	}

	void FixedUpdate() {
		if(cooldown > 0) {
			cooldown--;
		}
		UICooldown.text = (100 - (cooldown * 100 / RetardoDisparo)) + "%";
	}

	void Update() {
		if(!Pausa.EnPausa) {	//Ultima linea agregada
			Vector2 Puntero = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			ActualizarTrazada(Puntero);
			if(cooldown == 0) {
				if(Input.GetMouseButtonDown(0)) {
					Disparar(Puntero);
				}
			}	
		}
	}

	void Disparar(Vector2 Puntero) {
		Flecha FlechaClase = flecha.GetComponent<Flecha>();
		FlechaClase.ModuloFuerzaSalida = ModuloFuerzaSalida(Puntero);
		FlechaClase.AnguloSalida = CalcularAnguloSalida(Puntero);
		cooldown = RetardoDisparo;
		Instantiate<GameObject>(flecha).SetActive(true);
	}
	
	void ActualizarTrazada(Vector2 Puntero) {
		float ModuloFuerza = ModuloFuerzaSalida(Puntero),
			  AnguloInicial = CalcularAnguloSalida(Puntero);
		Vector2 Actual = new Vector2(0f,6f);
		for (int i = 0; i < trazada.positionCount; i++) {
            float aux = i * 0.1f;
			Actual.x = ModuloFuerza * aux * Mathf.Cos(AnguloInicial);
			Actual.y = 6f + (ModuloFuerza * aux * Mathf.Sin(AnguloInicial)) - ((-Physics2D.gravity.y * Mathf.Pow(aux, 2))/2);
			trazada.SetPosition(i, Actual);
		}
	}

	float ModuloFuerzaSalida(Vector2 Puntero) {
		if(Puntero.x < 0) {
			Puntero.x = 0f;
		}
		float res = Mathf.Sqrt( Mathf.Pow(Puntero.x,2) + Mathf.Pow(Puntero.y - 6f, 2) ) * 2;
		if(res > FuerzaMaxima) {
			return FuerzaMaxima;
		} else {
			if(res < 0) {
				return 0f;
			}
		}
		return res;
	}

	float CalcularAnguloSalida(Vector2 puntero) {
		return Mathf.Atan2(puntero.y - 6f, puntero.x);
	}

}