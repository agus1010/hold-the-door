using UnityEngine;

public class Bala : MonoBehaviour {

	Vector2 pos;
	Rigidbody2D CuerpoRigido;
	public GameObject Explosion;
	public float RadioDeExplosion;
	float FuerzaDeSalida;
	bool fueDetenida;
    static GameObject ExplosionStatic;

	Vector2 pos1 {
		get {
			return new Vector2(pos.x - 3, pos.y + 2);
		}
	}
	Vector2 pos2 {
		get {
			return new Vector2(pos.x + 3, pos.y);
		}
	}

	public void setFuerzaDeSalida(float fuerza) {
		FuerzaDeSalida = fuerza;
	}

    void Start () {
		CuerpoRigido = GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>().position;
		float AnguloSalida = Mathf.Atan2(pos.y-2.5f, pos.x);
		CuerpoRigido.velocity = new Vector2(-(FuerzaDeSalida*Mathf.Cos(AnguloSalida)), -(FuerzaDeSalida*Mathf.Sin(AnguloSalida)));
		fueDetenida = false;
        ExplosionStatic = Instantiate(Explosion);
    }

	void OnTriggerEnter2D(Collider2D c) {
		if(c.gameObject.tag == "Flecha") {
			CuerpoRigido.velocity = new Vector2(0f, CuerpoRigido.velocity.y);
			CuerpoRigido.gravityScale = 2;
			fueDetenida = true;
		}
		if(c.gameObject.tag == "Terreno" && fueDetenida) {
			pos = GetComponent<Transform>().position; 
			GameObject exp = Instantiate(ExplosionStatic);
			exp.SetActive(true);
			exp.GetComponent<Explosion>().Desaparece = true;
			exp.GetComponent<Transform>().position = new Vector2(pos.x, pos.y + 1f);
			exp.GetComponent<Transform>().localScale = new Vector3(5f, 2f, 0f);
			Collider2D[] afectados = Physics2D.OverlapAreaAll(pos1, pos2);
			foreach (var afectado in afectados) {
				string tag = afectado.tag;
				if (tag != "Terreno" && tag != "Puerta") {
					if(tag == "Orco") {
						afectado.gameObject.SendMessage("Morir");
					}
				}
			}
		}
	}

}
