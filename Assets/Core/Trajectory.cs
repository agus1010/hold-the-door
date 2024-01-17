using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JolDeFort
{
	[RequireComponent(typeof(LineRenderer))]
	public class Trajectory : MonoBehaviour
	{
		private LineRenderer _lineRenderer;
		private LineRenderer lineRenderer => (_lineRenderer ?? GetComponent<LineRenderer>());


		private Func<int, Vector3> _function;
		public Func<int, Vector3> function
		{
			get => _function;
			set => _function = value ?? (x => Vector3.zero);
		}

		public int pointsAmount
		{
			get => lineRenderer.positionCount;
			set => lineRenderer.positionCount = value;
		}


		public IEnumerable<Vector3> CalculateAllPositions()
			=> Enumerable.Range(0, pointsAmount).Select(x => function(x));

		public void Draw()
			=> lineRenderer.SetPositions(CalculateAllPositions().ToArray());

		public void DrawAt(int x)
			=> lineRenderer.SetPosition(x, function(x));


		private void Awake()
		{
			Reset();
		}

		private void Reset()
		{
			_lineRenderer = lineRenderer;
			lineRenderer.positionCount = pointsAmount;
		}
	}
}