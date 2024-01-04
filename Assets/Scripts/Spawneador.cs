using UnityEngine;


public class Spawneador : MonoBehaviour {

	public GameObject[] Entidades;
	
	public GameObject Puerta;

	public bool finDelJuego;

	float cooldownOrco;
    float cooldownGlobo;

	Horda hordaActual;

	void Start() {
		/*cooldownOrco = Mathf.RoundToInt(Random.Range(10f, 20f));
        cooldownGlobo = Mathf.RoundToInt(Random.Range(50f, 75f));*/
        finDelJuego = false;
		//hordaActual = new Horda(Entidades,20);
	}

	void FixedUpdate() {
		if(!hordaActual.FinDeHorda) {
			try {
				//GameObject instanciado = Instantiate<GameObject>(hordaActual.Spawn());
				//instanciado.SetActive(true);
			} catch { }
		} else {
			//hordaActual = new Horda(Entidades,20);
		}
		/*if(cooldownOrco != 0) {
			cooldownOrco--;
		} else {
			cooldownOrco = Mathf.RoundToInt(Random.Range(20f, 40f));
			Instantiate(Entidades[0]).SetActive(true);
		}
        if (cooldownGlobo != 0) {
            cooldownGlobo--;
        } else {
            cooldownGlobo = Mathf.RoundToInt(Random.Range(200f, 300f));
            Instantiate(Entidades[1]).SetActive(true);
        }*/
    }
}