using UnityEngine;

using JolDeFort.Core;


namespace JolDeFort.Assets
{
	[RequireComponent(typeof(LineRenderer))]
	public class WeaponTrajectory : MonoBehaviour
	{
		[Min(0)] public int totalTrajectoryPoints = 10;
		[Range(0, 1)] public float trajectoryDetail = .01f;

		private LineRenderer lineRenderer;


		private void Start()
		{
			lineRenderer = GetComponent<LineRenderer>();
		}

		public void UpdateTrace(Vector2 pointerPosition, float force, float angle)
		{
			lineRenderer.positionCount = totalTrajectoryPoints;
			float offset;
			Vector2 current = transform.position;
			for (int i = 0; i < totalTrajectoryPoints; i++)
			{
				offset = i * trajectoryDetail;
				current.x += force * offset * Mathf.Cos(angle);
				current.y += (force * offset * Mathf.Sin(angle)) - ((-Physics2D.gravity.y * Mathf.Pow(offset, 2)) / 2);
				lineRenderer.SetPosition(i, current);
			}
		}
	}
}