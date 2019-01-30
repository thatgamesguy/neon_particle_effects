using UnityEngine;
using System.Collections;

namespace PE2D
{
	/// <summary>
	/// Emits particles from objects position in a random direction.
	/// </summary>
	public class ParticleEmitterInRandomDirection : CustomParticleEmitter
	{
		protected override void ReleaseParticle ()
		{
			Color colour = randomColour ? GetRandomColour () : particleColour;

			float speed = (18f * (1f - 1 / Random.Range (1f, 10f))) * 0.01f;
		
			_cachedState.velocity = StaticExtensions.Random.RandomVector2 (speed, speed);
		
			ParticleFactory.instance.CreateParticle (transform.position, colour, duration, initialScale, _cachedState);
		}
	}
}
