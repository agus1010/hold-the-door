using UnityEngine;

public class Ronda {

	public static int Numero {
        get;
        private set;
    }
    static Ronda instancia;
    public static Ronda Instancia {
        get {
            if(instancia == null) {
                instancia = new Ronda();
            }
            return instancia;
        }
    }

    public int MaxSpawneosTotales;
    int cantOrcos {
        get {
            return 20 + Numero * 5;
        }
    }
    int cantGlobos {
        get {
            return 20 * cantOrcos / 100;
        }
    }

    public bool FinDeRonda {
        get {
            return MaxSpawneosTotales == 0;
        }
    }

	public RondaUI rondaUI;

    public static void NuevaRonda() {
        instancia = new Ronda();
    }

    private Ronda() {
		Numero++;
        MaxSpawneosTotales = cantOrcos + cantGlobos;
		RondaUI.ActualizarRonda(Numero);
        Debug.Log(MaxSpawneosTotales + " Ronda: " + Numero);
    }

    public Horda setNuevaHorda(GameObject g) {
        if (g.tag == "Orco") {
            return new Horda(g,20 + Numero * 5);
        } else {
            return new Horda(g, 20 * (20 + Numero * 5) / 100);
        }
    }

}
