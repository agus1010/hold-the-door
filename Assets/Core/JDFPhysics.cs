using UnityEngine;

// https://en.wikipedia.org/wiki/Trajectory
// https://es.wikipedia.org/wiki/Trayectoria_bal%C3%ADstica


namespace JolDeFort.Core
{
	public class JDFPhysics
	{
		public static float CalculateExitAngle(Vector2 initialPosition, Vector2 desiredPosition)
			=> Mathf.Atan2(desiredPosition.y - initialPosition.y, desiredPosition.x - initialPosition.x);

		/*public static float CalculateProjectileHeight()
		{

		}

		public static Vector2 CalculateNecesaryForce(float mass, float angle, Vector2 )
		{
			// F = m*a

		}*/

		public static Vector2 LerpProjectileVelocity(Vector2 initialPosition, float force, float angle, float t)
		{
			initialPosition.x = force * t * Mathf.Cos(angle);
			initialPosition.y = force * t * Mathf.Sin(angle);
			return initialPosition;
		}

		public static Vector2 LerpProjectilePosition(Vector2 initialPosition, float force, float angle, float t)
		{
			initialPosition = LerpProjectileVelocity(initialPosition, force, angle, t);
			initialPosition.y -= 0.5f * (-Physics2D.gravity.y * Mathf.Pow(t, 2));
			return initialPosition;
		}
	}
}