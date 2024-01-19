namespace JolDeFort.Core
{
	public interface ILineFunctionProvider
	{
		public System.Func<float, UnityEngine.Vector3> function { get; }
	}
}