using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JolDeFort.Core
{
	[RequireComponent(typeof(LineRenderer))]
	public class LineFunctionRenderer : MonoBehaviour
	{
		[SerializeField] private int _firstIndex = 0;
		[SerializeField] private int _lastIndex = 100;
		[Range(.00001f, 1f)] public float distanceBetweenPoints = 1.0f;

		public int firstIndex
		{
			get => _firstIndex;
			set
			{
				_firstIndex = value;
				setPositionCount();
			}
		}
		public int lastIndex
		{
			get => _lastIndex;
			set
			{
				_lastIndex = value;
				setPositionCount();
			}
		}
		public int pointsAmount => lineRenderer.positionCount;
		public LineRenderer lineRenderer => (_lineRenderer ?? GetComponent<LineRenderer>());

		private LineRenderer _lineRenderer;


		public void Draw(ILineFunctionProvider trajectoryFunctionProvider)
			=> Draw(trajectoryFunctionProvider.function);

		public void Draw(System.Func<float, Vector3> function)
			=> Draw(firstIndex, lastIndex, function);

		public void Draw(int firstIndex, int lastIndex, ILineFunctionProvider trajectoryFunctionProvider)
			=> Draw(firstIndex, lastIndex, trajectoryFunctionProvider.function);

		public void Draw(int firstIndex, int lastIndex, System.Func<float, Vector3> function)
			=> lineRenderer.SetPositions(getPositions(firstIndex, lastIndex, function).ToArray());


		private void Awake()
		{
			Reset();
		}

		private void Reset()
		{
			_lineRenderer = lineRenderer;
			lineRenderer.positionCount = pointsAmount;
			lineRenderer.useWorldSpace = false;
			setPositionCount();
		}


		private IEnumerable<Vector3> getPositions(int firstPos, int lastPos, System.Func<float, Vector3> function)
			=> Enumerable.Range(firstPos, lastPos).Select(i => function(nextIndex(i)));

		private void setPositionCount()
			=> lineRenderer.positionCount = System.Math.Abs(_firstIndex - _lastIndex);

		private float nextIndex(int index)
			 => index * distanceBetweenPoints;
	}
}