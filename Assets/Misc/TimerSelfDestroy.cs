using UnityEngine;


namespace JolDeFort.Misc
{
    public class TimerSelfDestroy : MonoBehaviour
    {
        [Range(.01f, 25f)] public float selfDestructionTime = .5f;

        private float timeElapsedSinceInstatiation = 0f;

        private void Update()
        {
            timeElapsedSinceInstatiation += Time.deltaTime;
            if (timeElapsedSinceInstatiation > selfDestructionTime)
                Destroy(gameObject);
        }
    }
}