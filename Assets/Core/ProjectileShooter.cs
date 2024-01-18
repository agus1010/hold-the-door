using UnityEngine;


namespace JolDeFort.Core
{
	public class ProjectileShooter : MonoBehaviour
	{
		public ForceProvider forceProvider;

		public void Shoot()
		{

		}



		private float calcExitAngle()
			=> Mathf.Atan2(pointerPosition.y - 6f, pointerPosition.x);

		private Vector3 calcOutputVelocity()
			=> new Vector3(
					m_frameOutputForce * Mathf.Cos(m_frameExitAngle),
					m_frameOutputForce * Mathf.Sin(m_frameExitAngle),
					0f
				);
	}
}