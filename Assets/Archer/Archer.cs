using UnityEngine;

using JolDeFort.Core;


namespace JolDeFort.Assets
{
	public class Archer : MonoBehaviour
	{
		public float maxForce = 10f;
		public float currentCooldown = 0f;
		public float maxCooldown = 1f;

		[SerializeField] private PlayerInputs playerInputs;
		[SerializeField] private GameObject arrowPrefab;
		[SerializeField] private WeaponTrajectory weaponTrajectory;

		private Vector2 pointerPosition => playerInputs.CursorPosition;

		private float m_frameExitAngle;
		private float m_frameOutputForce;


		public void Fire()
		{
			if (currentCooldown > 0f)
				return;
			GameObject newArrow = Instantiate(arrowPrefab);
			newArrow.transform.position = transform.position;
			newArrow.GetComponent<Rigidbody2D>().velocity = calcOutputVelocity();
			currentCooldown = maxCooldown;
		}


		private void Update()
		{
			m_frameExitAngle = calcExitAngle();
			m_frameOutputForce = calcOutputForceModulus();
			weaponTrajectory.UpdateTrace(pointerPosition, maxForce, m_frameExitAngle);
			if (currentCooldown > 0f)
				currentCooldown = Mathf.Max(0, currentCooldown - Time.deltaTime);
		}

		
		private float calcOutputForceModulus()
			=> Mathf.Clamp(
				value: 2 * Mathf.Sqrt(Mathf.Pow(Mathf.Max(0, pointerPosition.x), 2) + Mathf.Pow(pointerPosition.y, 2)),
				min: 0,
				max: maxForce
			);

		private float calcExitAngle()
			=> Mathf.Atan2(pointerPosition.y - 6f, pointerPosition.x);

		private Vector2 calcOutputVelocity()
			=> new Vector2(
					m_frameOutputForce * Mathf.Cos(m_frameExitAngle),
					m_frameOutputForce * Mathf.Sin(m_frameExitAngle)
				);
	}
}