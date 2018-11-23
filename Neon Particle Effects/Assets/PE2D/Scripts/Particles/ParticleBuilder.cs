using UnityEngine;
using System.Collections;

namespace PE2D
{
	/// <summary>
	/// Screen constraint type. 
	/// </summary>
	public enum WrapAroundType
	{
		None,
		WrapAround,
		Constrain
	}

	/// <summary>
	/// Holds the particle state. Passed to the ParticleFactory to build particles.
	/// </summary>
	public struct ParticleBuilder
	{
		/// <summary>
		/// Initial velocity of particle.
		/// </summary>
		public Vector2 velocity;

		/// <summary>
		/// Screen constraint type.
		/// </summary>
		public WrapAroundType wrapAroundType;

		/// <summary>
		/// The particles scale is multipled by this.
		/// </summary>
		public float lengthMultiplier;

		/// <summary>
		/// The percentage amount that a particles velocity remains each timestep.
		/// </summary>
		public float velocityDampModifier;

		/// <summary>
		/// If enables, the particle built with this state will ignore effectors.
		/// </summary>
		public bool ignoreEffectors;

		#region optional variables
		/// <summary>
		/// Clamp the minimum length of a particles sprite.
		/// </summary>
		public float? minLengthClamp;

		/// <summary>
		/// Clamp the maximum length of a particles sprite.
		/// </summary>
		public float? maxLengthClamp;

		/// <summary>
		/// Will remove a particle if velocity reaches a threshold.
		/// </summary>
		public bool? removeWhenVelocityReachesThreshold;

		/// <summary>
		/// The velocity at which a particle will be removed, only used if #removeWhenVelocityReachesThreshold = true.
		/// </summary>
		public float? customVelocityThreshold;

		/// <summary>
		/// Will remove the particle when its alpha reaches a specified threshold.
		/// </summary>
		public bool? removeWhenAlphaReachesThreshold;

		/// <summary>
		/// The particles sprites alpha threshold at which a particle will be removed, only used if #removeWhenAlphaReachesThreshold = true.
		/// </summary>
		public float? customAlphaThreshold;
		#endregion
	}
	
}
