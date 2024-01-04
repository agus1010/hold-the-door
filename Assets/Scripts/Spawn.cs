using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject TipoSpawn;

    static int DelayEntreRondas;
    static int DelayProxRondaActual;

    public int CooldownMinimo;
    public int CooldownMaximo;
    int CooldownTotal;
    int CooldownActual;

    Horda horda;
	
    void Start() {
        reiniciarCooldowns();
        DelayEntreRondas = 600;
        horda = Ronda.Instancia.setNuevaHorda(TipoSpawn);
    }
    
	void FixedUpdate () {
        if(CooldownActual >= CooldownTotal) {
            if (!Ronda.Instancia.FinDeRonda) {
                if (!horda.FinDeHorda) {
                    horda.SpawnearIndividuo();
                } else {
                    horda = Ronda.Instancia.setNuevaHorda(TipoSpawn);
                }
                reiniciarCooldowns();
            } else {
                if(DelayProxRondaActual != 0) {
                    DelayProxRondaActual--;
                } else {
                    DelayProxRondaActual = DelayEntreRondas;
                    Ronda.NuevaRonda();
                }
            }
        } else {
            CooldownActual++;
        }
	}

    void reiniciarCooldowns() {
        CooldownActual = 0;
        CooldownTotal = Random.Range(CooldownMinimo, CooldownMaximo);
    }

}
