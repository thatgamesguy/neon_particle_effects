using UnityEngine;
using System.Collections;

namespace PE2D
{
	/// <summary>
	/// Base class for ParticleEmitterInRandomDirection and ParticleEmitterInObjectDirection. Add base classes to GameObjects to
	/// easily create particle emitters.
	/// </summary>
	public abstract class CustomParticleEmitter : MonoBehaviour
	{
		/// <summary>
		/// The time between projectile release, if equals 0 then particle is released with each call to update.
		/// </summary>
		public float timeBetweenProjectileRelease = 0f;

		/// <summary>
		/// Initial scale of the particles released. Scale is also dependent on velocity.
		/// </summary>
		public Vector2 initialScale = new Vector2 (2f, 1f);

		/// <summary>
		/// Turns on/off particle generation from this GameObject.
		/// </summary>
		public bool particlesEnabled = true;

		/// <summary>
		/// The maximum duration for each particle. A particles life is also dependent on velocity.
		/// </summary>
		public float duration = 90f;

		/// <summary>
		/// THe rate at which to reduce particles velocity each time step.
		/// </summary>
		public float velocityDampener = 0.94f;

		/// <summary>
		/// The length multiplier for the particles.
		/// </summary>
		public float lengthMultiplier = 40f;

		/// <summary>
		/// The screen constraint type.
		/// </summary>
		public WrapAroundType wrapAround = WrapAroundType.None;

		/// <summary>
		/// Particle will spawn as a random colour when enabled.
		/// </summary>
		public bool randomColour = false;

		/// <summary>
		/// Set the particles colour.
		/// </summary>
		public Color particleColour;

	#region Optional Parameters
		/// <summary>
		/// Clamp the minimum length of a particle.
		/// </summary>
		public bool clampMinLength;

		/// <summary>
		/// The minimum length of a particle, only used if #clampMinLength = true.
		/// </summary>
		public float minLength;

		/// <summary>
		/// Clamp the maximum length of a particle.
		/// </summary>
		public bool clampMaxLength;

		/// <summary>
		/// The minimum length of a particle, only used if #clampMaxLength = true.
		/// </summary>
		public float maxLength;

		/// <summary>
		/// Will remove a particle if velocity reaches a threshold.
		/// </summary>
		public bool removeWhenVelocityReachesThreshold;

		/// <summary>
		/// The velocity at which a particle will be removed, only used if #removeWhenVelocityReachesThreshold = true.
		/// </summary>
		public float customVelocityThreshold;

		/// <summary>
		/// Will remove the particle when its alpha reaches a specified threshold.
		/// </summary>
		public bool removeWhenAlphaReachesThreshold;

		/// <summary>
		/// The particles sprites alpha threshold at which a particle will be removed, only used if #removeWhenAlphaReachesThreshold = true.
		/// </summary>
		public float customAlphaThreshold;
	#endregion

		private float _currentTime;

		protected ParticleBuilder _cachedState;

		void OnEnable ()
		{
			_currentTime = 0f;

			CacheState ();
		}
	
		void Update ()
		{
			if (!particlesEnabled)
				return;

			_currentTime += Time.deltaTime;
		
			if (_currentTime > timeBetweenProjectileRelease) {
				ReleaseParticle ();
				_currentTime = 0f;
			}
		}

		/// <summary>
		/// Enables particle emission from this object.
		/// </summary>
		public void TurnOn ()
		{
			particlesEnabled = true;
		}

		/// <summary>
		/// Disables particle emission from this object.
		/// </summary>
		public void TurnOff ()
		{
			particlesEnabled = false;
		}

		protected Color GetRandomColour ()
		{
			float hue1 = Random.Range (0, 6);
			float hue2 = (hue1 + Random.Range (0, 2)) % 6f;
			Color colour1 = StaticExtensions.Color.FromHSV (hue1, 0.5f, 1);
			Color colour2 = StaticExtensions.Color.FromHSV (hue2, 0.5f, 1);
			
			return Color.Lerp (colour1, colour2, Random.Range (0, 1));
		}

		protected abstract void ReleaseParticle ();

		private void CacheState ()
		{
			_cachedState = new ParticleBuilder ()
			{
				velocity = Vector2.zero,  
				wrapAroundType = wrapAround,
				lengthMultiplier = this.lengthMultiplier,
				velocityDampModifier = velocityDampener,
				removeWhenAlphaReachesThreshold = true
			};

			if (clampMinLength) {
				_cachedState.minLengthClamp = minLength;
			}

			if (clampMaxLength) {
				_cachedState.maxLengthClamp = maxLength;
			}

			if (removeWhenVelocityReachesThreshold) {
				_cachedState.customVelocityThreshold = customVelocityThreshold;
			}

			if (removeWhenAlphaReachesThreshold) {
				_cachedState.customAlphaThreshold = customAlphaThreshold;
			}

		}
	}
}
