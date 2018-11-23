using UnityEngine;
using System.Collections;

namespace PE2D
{
	/// <summary>
	/// Simple renderer script for particles that disables the sprite renderer on enable and
	/// re-enables the srpite renderer after a time specified by ParticleRenderer#RENDERER_DELAY. Attach to the particle
	/// prefab to prevent occasional graphic glitches.
	/// </summary>
	[RequireComponent (typeof(SpriteRenderer))]
	public class ParticleRenderer : MonoBehaviour
	{

		private SpriteRenderer _renderer;

		private static readonly float RENDERER_DELAY = .01f;

		void Awake ()
		{
			_renderer = GetComponent<SpriteRenderer> ();
		}

		void OnEnable ()
		{
			_renderer.enabled = false;
			StartCoroutine (EnableRenderer ());
		}

		void OnDisable ()
		{
			StopCoroutine (EnableRenderer ());
		}

		private IEnumerator EnableRenderer ()
		{
			yield return new WaitForSeconds (RENDERER_DELAY);
			_renderer.enabled = true;
		}
	

	}
}
