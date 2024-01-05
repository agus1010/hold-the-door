using UnityEngine;


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


		private float m_offset;
		private Vector2 m_position;
		private Vector2 m_current = Vector3.zero;
		public void UpdateTrace(Vector2 pointerPosition, float force, float angle)
		{
			lineRenderer.positionCount = totalTrajectoryPoints;
			m_position = transform.position;
			for (int i = 0; i < totalTrajectoryPoints; i++)
			{
				m_offset = i * trajectoryDetail;
				m_current.x = m_position.x + force * m_offset * Mathf.Cos(angle);
				m_current.y = m_position.y + (force * m_offset * Mathf.Sin(angle)) - ((-Physics2D.gravity.y * Mathf.Pow(m_offset, 2)) / 2);
				lineRenderer.SetPosition(i, m_current);
			}
		}
	}
}