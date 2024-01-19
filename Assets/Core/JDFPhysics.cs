using UnityEngine;

// https://en.wikipedia.org/wiki/Trajectory
// https://es.wikipedia.org/wiki/Trayectoria_bal%C3%ADstica


namespace JolDeFort.Core
{
	public class JDFPhysics
	{

		public static float ExitAngle(Vector2 desiredPosition)
			=> Mathf.Atan2(desiredPosition.y, desiredPosition.x);
		public static float ExitAngle(Vector2 initialPosition, Vector2 desiredPosition)
			=> Mathf.Atan2(desiredPosition.y - initialPosition.y, desiredPosition.x - initialPosition.x);

		/*public static float CalculateProjectileHeight()
		{

		}*/

		public static float ExitForceModulus(float mass, Vector2 maxHeightPosition)
			// mass * sqrt(x^2 + y^2)
			=> mass * Mathf.Sqrt(Mathf.Pow(maxHeightPosition.x, 2) + Mathf.Pow(maxHeightPosition.y, 2));

		//public static Vector2 CalculateNecesaryForce(float mass, )

		public static Vector2 CalculateNecesaryForce(float mass, float angle, Vector2 desiredPosition)
		{
			// F = m*a
			return Vector2.zero;
		}

		public static Vector2 LerpProjectileVelocity(Vector2 initialPosition, float force, float angle, float t)
		{
			initialPosition.x = force * t * Mathf.Cos(angle);
			initialPosition.y = force * t * Mathf.Sin(angle);
			return initialPosition;
		}

		public static Vector3 LerpProjectileVelocity(Vector3 exitVelocity, float t)
			=> exitVelocity + Physics.gravity * t;

		public static Vector2 LerpProjectilePosition(Vector2 initialPosition, float forceModulus, float angle, float t)
		{
			initialPosition = LerpProjectileVelocity(initialPosition, forceModulus, angle, t);
			initialPosition.y -= 0.5f * (-Physics2D.gravity.y * Mathf.Pow(t, 2));
			return initialPosition;
		}
	}
}


/*public static float ExitForceModulus(Vector2 Puntero)
		{
			if (Puntero.x < 0)
			{
				Puntero.x = 0f;
			}
			float res = Mathf.Max(0, Mathf.Sqrt(Mathf.Pow(Puntero.x, 2) + Mathf.Pow(Puntero.y - 6f, 2)) * 2);
			// clamp between 0 and max_force
			return res;
		}

		public static float ExitAngle(Vector2 puntero)
		{
			return Mathf.Atan2(puntero.y, puntero.x);
		}



		public static Vector3 LerpProjectilePosition(Vector2 Puntero, float t)
		{
			float ModuloFuerza = ExitForceModulus(Puntero),
				  AnguloInicial = ExitAngle(Puntero);
			return new Vector3 (
				x: ModuloFuerza * Mathf.Cos(AnguloInicial),
				y: (ModuloFuerza * Mathf.Sin(AnguloInicial)) - ((-Physics2D.gravity.y * Mathf.Pow(t, 2)) / 2),
				z: 0f
			);
		}

		/*public static Vector3 LerpProjectilePosition(Vector3 exitForce , float t)
		{
			return exitForce + Physics.gravity * t;
		}
	}
}*/