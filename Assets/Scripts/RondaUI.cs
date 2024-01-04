using UnityEngine;
using UnityEngine.UI;

public class RondaUI : MonoBehaviour {

	static int NumeroAImprimir;
	public Text ronda;
	RectTransform transf;

	void Start () {
		ronda = GetComponent<Text>();
		transf = GetComponent<RectTransform>();
	}

	public static void ActualizarRonda(int numero) {
		NumeroAImprimir = numero;
	}

	void FixedUpdate() {
		ronda.text = NumeroAImprimir.ToString();
	}

}
