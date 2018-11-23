using UnityEngine;
using System.Collections;

namespace PE2D
{
	/// <summary>
	/// Effector types. Attraction pulls particles towards object, repel pushes particles away from object, and blackhole
	/// attracts objects until a certain point and then the particle encircles the object.
	/// </summary>
	public enum EffectorType
	{
		Attraction,
		Repel,
		BlackHole
	}

	/// <summary>
	/// Add to a gameobject to effect a particles movement.
	/// </summary>
	public class ParticleEffector : MonoBehaviour
	{
		public EffectorType effectorType;
		public float distance;

		//when blackhole
		public float rotateDistance;
		public float force;

	}
}
