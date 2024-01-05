using UnityEngine;

using JolDeFort.Misc;


namespace JolDeFort.Assets
{
	[RequireComponent(typeof(FrameTimer))]
	public class ForceProvider : MonoBehaviour
	{
		[Min(1f)] public float baseForce = 10f;
		public float maxForce = 35f;
		[Range(.00001f, 10f)] public float forceMultiplier = .1f;

		private FrameTimer frameTimer;


		public float CalculateCurrentForce(Vector2 pointerPosition)
			=> CalculateCurrentForce(frameTimer.timeElapsed, pointerPosition);

		public float CalculateCurrentForce(float attackHoldTime, Vector2 pointerPosition)
		{
			float baseForceModulus = 2 * Mathf.Sqrt(Mathf.Pow(Mathf.Max(0, pointerPosition.x), 2) + Mathf.Pow(pointerPosition.y, 2));
			float modifiedForceModulus = baseForceModulus + forceMultiplier * attackHoldTime;
			return Mathf.Clamp(modifiedForceModulus, baseForce, maxForce);
		}


		private void Awake()
		{
			frameTimer = GetComponent<FrameTimer>();
		}
	}
}