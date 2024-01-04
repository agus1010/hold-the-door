using UnityEngine;

public class Globo : MonoBehaviour {

    Rigidbody2D CuerpoRigido;
    Transform posicion;
    float gravedad;
    float Disparo {
        get {
            return Random.Range(0, 100);
        }
    }
    float PosibilidadDeDisparo {
        get {
            return 25;
        }
        //A medida que se acerca al jugador, mayor es la posibilidad de que dispare
        /*get {
            return 100 - x * 100 / 34;
        }*/
    }
    public int cadenciaDeFuegoTotal;
    int cadenciaDeFuegoActual;

	public float FuerzaDeDisparo;
    public GameObject bala;
    public GameObject explosion;

    float x { get { return posicion.position.x; } }
    float y { get { return posicion.position.y; } }

    void Start () {
        CuerpoRigido = GetComponent<Rigidbody2D>();
        gravedad = 0;
        CuerpoRigido.AddForce(new Vector2(-75f,0f));
        posicion = GetComponent<Transform>();
        cadenciaDeFuegoActual = 0;
    }
	
	void FixedUpdate () {
        ActualizarAltura();
        if (x <= 30f && x >= 4) {
            if (cadenciaDeFuegoActual == cadenciaDeFuegoTotal) {
                if (Disparo <= PosibilidadDeDisparo) {
                    Disparar();
                    cadenciaDeFuegoActual = 0;
                }
            } else {
                cadenciaDeFuegoActual++;
            }
        }
    }

    void ActualizarAltura() {
        CuerpoRigido.velocity = new Vector2(CuerpoRigido.velocity.x, Mathf.Sin(gravedad));
        gravedad += 0.05f;
        if (gravedad == 2) {
            gravedad = 0;
        }
    }

    void Disparar() {
        GameObject balaClon = Instantiate(bala);
        balaClon.SetActive(true);
        balaClon.GetComponent<Transform>().position = new Vector2(x - 1.56f, y - 2f);
		balaClon.GetComponent<Bala>().setFuerzaDeSalida(FuerzaDeDisparo);
		balaClon.GetComponent<Bala>().Explosion = explosion;
        explosion.SetActive(true);
    }

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Flecha") {
			Destroy(gameObject);
		}
	}

}
