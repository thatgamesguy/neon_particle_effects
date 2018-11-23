using UnityEngine;
using System.Collections;

namespace PE2D
{
	/// <summary>
	/// Emits particles based on objects rotation.
	/// </summary>
	public class ParticleEmitterInObjectDirection : CustomParticleEmitter
	{
		protected override void ReleaseParticle ()
		{
			Color colour = randomColour ? GetRandomColour () : particleColour;

			_cachedState.velocity = (transform.rotation * Vector2.up) * .2f;

			
			ParticleFactory.instance.CreateParticle (transform.position, colour, duration, initialScale, _cachedState);
		}
	}
}
