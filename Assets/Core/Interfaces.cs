using System.Collections;
using UnityEngine;


namespace JolDeFort.Core
{
	public interface ITrajectoryFunctionProvider
	{
		public System.Func<int, Vector3> function { get; }
	}
}