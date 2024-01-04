using UnityEngine;

namespace Utiles {

	public class Delay : MonoBehaviour{

		public int Total { get; set; }
		int Actual;
		public bool LuzVerde {
			get {
				return Actual == Total;
			}
		}

		void FixedUpdate() {
			if(Actual < Total) {
				Actual++;
			}
		}

	}

}