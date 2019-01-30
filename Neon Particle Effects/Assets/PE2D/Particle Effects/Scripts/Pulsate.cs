using UnityEngine;
using System.Collections;

namespace PE2D
{
	/// <summary>
	/// Simple script used to pulse an objects size. Used in the demo scene for the effectors.
	/// </summary>
	public class Pulsate : MonoBehaviour
	{
		private float _initialScale;

		void Awake ()
		{
			_initialScale = transform.localScale.x;
		}

		void Update ()
		{
			var s = _initialScale + 0.1f * (float)Mathf.Sin (10 * Time.realtimeSinceStartup);
			transform.localScale = new Vector3 (s, s, s);
		}

	}
}
