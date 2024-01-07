using JolDeFort.Core;
using UnityEngine;


namespace JolDeFort.Assets
{
	[RequireComponent(typeof(LineRenderer))]
	public class WeaponTrajectory : MonoBehaviour
	{
		[Min(0)] public int totalTrajectoryPoints = 10;
		[Range(0.1f, 1)] public float trajectoryDetail = .01f;

		private LineRenderer lineRenderer;


		private void Start()
		{
			lineRenderer = GetComponent<LineRenderer>();
			lineRenderer.positionCount = totalTrajectoryPoints;
		}



		public void Draw(float force, float angle)
			=> Draw(force, angle, transform.position);


		public void Draw(float force, float angle, Vector2 startPosition)
		{
			for (int i = 0; i < lineRenderer.positionCount; i++)
				lineRenderer.SetPosition(i, JDFPhysics.LerpProjectilePosition(startPosition, force, angle, i * trajectoryDetail));
		}
	}
}