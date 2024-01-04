using UnityEngine;

public class Nube : MonoBehaviour {

    Rigidbody2D CuerpoRigido;
    Transform pos;
    Vector2 PosicionInicial;
    float x { get { return pos.position.x; } }
    public float VelocidadDeSalida;

	void Start () {
        pos = GetComponent<Transform>();
        PosicionInicial = pos.position;
        CuerpoRigido = GetComponent<Rigidbody2D>();
        CuerpoRigido.velocity = new Vector2(-VelocidadDeSalida,0f);
	}
	
	void Update () {
		if(x <= -6f) {
            pos.position = PosicionInicial;
        }
	}
}
