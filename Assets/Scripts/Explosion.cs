using UnityEngine;

public class Explosion : MonoBehaviour {

    Transform pos;
	int escalada;
	public bool Desaparece;

	void Start () {
        pos = GetComponent<Transform>();
		escalada = 0;
	}
	
	void Update () {
        pos.localScale += new Vector3(0.1f, 0.1f, 0f);
		escalada++;
		if(escalada == 5) {
            pos.localScale = new Vector3(0.1f, 0.1f, 1f);
			escalada = 0;
			if(!Desaparece) {
				gameObject.SetActive(false);
			} else {
				Destroy(gameObject);
			}
        }
	}
}
