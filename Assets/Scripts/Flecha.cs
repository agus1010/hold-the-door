using UnityEngine;

public class Flecha : MonoBehaviour {

	public float ModuloFuerzaSalida;
	public float AnguloSalida;
	
	void Start() {
		GetComponent<Rigidbody2D>().velocity = new Vector2(
			ModuloFuerzaSalida * Mathf.Cos(AnguloSalida),
			ModuloFuerzaSalida * Mathf.Sin(AnguloSalida)
		);
	}

	void OnTriggerEnter2D(Collider2D c) {
		if(c.tag != "Puerta" && c.tag != "GameController") {
			if (c.tag == "Orco") {
				c.gameObject.SendMessage("Morir");
			}
			Destroy(gameObject);
		}
	}

}