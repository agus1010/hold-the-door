using UnityEngine;

using JolDeFort.Core;


namespace JolDeFort.Assets
{
	public class Archer : MonoBehaviour
	{
		public float currentCooldown = 0f;
		public float maxCooldown = 1f; 

		[SerializeField] private PlayerInputs playerInputs;
		[SerializeField] private GameObject arrowPrefab;
		[SerializeField] private FunctionRenderer functionRenderer;
		[SerializeField] private ForceProvider forceProvider;

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
			m_frameExitAngle = JDFPhysics.CalculateExitAngle(transform.position, pointerPosition);
			m_frameOutputForce = forceProvider.Calculate(pointerPosition);
			System.Func<int, Vector3> trajectoryFunction = (x) => JDFPhysics.LerpProjectilePosition(transform.position, m_frameOutputForce, m_frameExitAngle, x);
			functionRenderer.Draw(trajectoryFunction);
			if (currentCooldown > 0f)
				currentCooldown = Mathf.Max(0, currentCooldown - Time.deltaTime);
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