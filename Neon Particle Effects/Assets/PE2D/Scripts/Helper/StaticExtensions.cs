using UnityEngine;
using System.Collections;

namespace PE2D
{
/// <summary>
///  Extensions for static classes. COntains a number of helper methods used throughout project.
/// </summary>
	public static class StaticExtensions
	{

		public static class Random
		{
			/// <summary>
			/// Randoms a random vector2 between minLength and maxLength.
			/// </summary>
			/// <returns>The vector2.</returns>
			/// <param name="minLength">Minimum length.</param>
			/// <param name="maxLength">Max length.</param>
			public static Vector2 RandomVector2 (float minLength, float maxLength)
			{
				float theta = UnityEngine.Random.value * 2 * Mathf.PI;
				float length = UnityEngine.Random.Range (minLength, maxLength);
				return new Vector2 (length * (float)Mathf.Cos (theta), length * (float)Mathf.Sin (theta));
			}
		}
	
		public static class Color
		{
			/// <summary>
			/// Converts hue, saturation, and value (hsv) to UnityEngine.Color.
			/// </summary>
			/// <returns> Converted colour.</returns>
			/// <param name="h">Hue.</param>
			/// <param name="s">Saturation.</param>
			/// <param name="v">Value.</param>
			public static UnityEngine.Color FromHSV (float h, float s, float v)
			{
				if (h == 0 && s == 0)
					return new UnityEngine.Color (v, v, v);
			
				float c = s * v;
				float x = c * (1 - Mathf.Abs (h % 2 - 1));
				float m = v - c;
			
				if (h < 1)
					return new UnityEngine.Color (c + m, x + m, m);
				else if (h < 2)
					return new UnityEngine.Color (x + m, c + m, m);
				else if (h < 3)
					return new UnityEngine.Color (m, c + m, x + m);
				else if (h < 4)
					return new UnityEngine.Color (m, x + m, c + m);
				else if (h < 5)
					return new UnityEngine.Color (x + m, m, c + m);
				else
					return new UnityEngine.Color (c + m, m, x + m);
			}
		}

	}
}
