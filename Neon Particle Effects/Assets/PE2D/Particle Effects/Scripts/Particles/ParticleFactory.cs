using UnityEngine;
using System.Collections;

namespace PE2D
{
	/// <summary>
	/// Creates and maintain an object pool of particles.
	/// 
	/// </summary>
	public class ParticleFactory : MonoBehaviour
	{
		/// <summary>
		/// Particle prefab.
		/// </summary>
		public GameObject particlePrefab;

		/// <summary>
		/// The max particle count. This number of particles is created at runtime and placed in a finite pool.
		/// </summary>
		public int maxParticleCount;
	
		private CircularArray<CustomParticle> _particleArray;
		
		private static ParticleFactory _instance;
		/// <summary>
		/// Gets the instance of this class. Can be called from any script. Only one instance of a particle factory can exist in one scene.
		/// 
		/// </summary>
		/// <value>The instance.</value>
		public static ParticleFactory instance { 
			get { 

				if (!_instance) {
					_instance = GameObject.FindObjectOfType<ParticleFactory> ();
				}

				return _instance; 
			} 
		}
		
		void Awake ()
		{
			if (!_instance) {
				_instance = this;
			}

			if (maxParticleCount <= 0) {
				Debug.LogError ("maxParticleCount must be greater than zero");
			}

			_particleArray = new CircularArray<CustomParticle> (maxParticleCount);
			
			for (int i = 0; i < _particleArray.Capacity; i++) {
				var particle = Instantiate (particlePrefab);
				particle.transform.SetParent (transform);
				particle.SetActive (false);
				_particleArray [i] = particle.GetComponent<CustomParticle> ();
			}

			CustomParticle.UpdateEffectorList ();
		}

		/// <summary>
		/// Creates a particle at position with the specified state.
		/// </summary>
		/// <param name="position">Initial position of particle.</param>
		/// <param name="tint">The initial colour of particle.</param>
		/// <param name="duration">The maximum duration of particle.</param>
		/// <param name="scale">Initial scale of particle.</param>
		/// <param name="state">THe particle state.</param>
		public void CreateParticle (Vector2 position, 
				Color colour, float duration, Vector2 initialScale, ParticleBuilder state)
		{
			CustomParticle particle;


			if (_particleArray.reachedCapacity) {
				particle = _particleArray [0];
				_particleArray.Start++;
				particle.gameObject.SetActive (false);
			} else {
				particle = _particleArray [_particleArray.Count];
				_particleArray.Count++;
			}
		
			particle.state = state;
			particle.percentLife = 1f;
			particle.duration = duration;

			particle.transform.position = position;
			particle.transform.localScale = initialScale;
			
			particle.spriteRenderer.color = colour;
			
		
			particle.gameObject.SetActive (true);
	
		}

		/// <summary>
		/// Sets all enabled particles to be removed in the next time step.
		/// </summary>
		public void RemoveAllActiveParticles ()
		{
			for (int i = _particleArray.Start; i < _particleArray.Count; i++) {
				_particleArray [i].percentLife = 0f;
			}
		}
		
		void Update ()
		{
			int removalCount = 0;
			
			for (int i = _particleArray.Start; i < _particleArray.Count; i++) {
				var particle = _particleArray [i];

				particle.percentLife -= 1f / particle.duration;
				Swap (i - removalCount, i);
				
				if (particle.percentLife <= 0f) {
					particle.gameObject.SetActive (false);
					removalCount++;
				}
			}
			
			_particleArray.Count -= removalCount;
		}
		
		private void Swap (int indexOne, int indexTwo)
		{
			var temp = _particleArray [indexOne];
			_particleArray [indexOne] = _particleArray [indexTwo];
			_particleArray [indexTwo] = temp;
		}


	}
	
	
}
