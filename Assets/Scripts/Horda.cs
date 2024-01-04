using UnityEngine;

public class Horda {
    
    GameObject TipoSpawn;
    int cantSpawneos;
    public bool FinDeHorda {
        get {
            return cantSpawneos == 0;
        }
    }

    public Horda(GameObject tipo, int cant) {
        TipoSpawn = tipo;
        cantSpawneos = cant;
    }

    public void SpawnearIndividuo() {
        if (!FinDeHorda) {
            cantSpawneos--;
            Ronda.Instancia.MaxSpawneosTotales--;
            MonoBehaviour.Instantiate(TipoSpawn).SetActive(true);
        }
    }
}
