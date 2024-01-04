using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour{
	
	Text cooldownUI;

	void Start() {
		cooldownUI = GetComponent<Text>();
	}

	public void mostrarCooldown(int cooldownActual, int cooldownTotal) {
		if (cooldownActual != cooldownTotal) {
			int porcentaje = cooldownActual * 100 / cooldownTotal;
			float aux = porcentaje * 255f / 100f;
			cooldownUI.color = new Color(255f, aux, aux, 255f);
			cooldownUI.text = porcentaje.ToString() + "%";
		} else {
			cooldownUI.text = "";
		}
	}
	
}
