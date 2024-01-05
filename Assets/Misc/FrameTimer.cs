using UnityEngine;


namespace JolDeFort.Misc
{
	public class FrameTimer : MonoBehaviour
	{
		public bool counting { get; private set; } = false;
		public float timeElapsed { get; private set; } = 0f;

		public void ChangeState(bool newState)
		{
			if (counting == newState) return;
			counting = newState;
			if (!counting)
				timeElapsed = 0f;
		}

		public void Trigger()
			=> ChangeState(!counting);


		private void Update()
		{
			if (!counting)
				return;
			timeElapsed += Time.deltaTime;
		}
	}
}