using UnityEngine;
using UnityEngine.UI;

public class Pausa : MonoBehaviour {

	bool enPausa = false;
	public static bool EnPausa;
	float escalaDeTiempo;
	Text PausaUI;

	void Start() {
		escalaDeTiempo = Time.timeScale;
		PausaUI = GetComponent<Text>();
		Cursor.visible = false;
		EnPausa = enPausa;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if(!enPausa) {
				Time.timeScale = 0f;
				PausaUI.text = "PAUSA";
				Cursor.visible = true;
			} else {
				Time.timeScale = 1;
				PausaUI.text = "";
				Cursor.visible = false;
			}
			enPausa = !enPausa;
			EnPausa = enPausa;
		}
	}
}
