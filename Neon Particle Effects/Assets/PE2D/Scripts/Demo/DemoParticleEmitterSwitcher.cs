using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PE2D;

/// <summary>
/// Switches between particle emitters in demo scene.
/// </summary>
public class DemoParticleEmitterSwitcher : MonoBehaviour
{
	public GameObject[] particleEmitters;

	public Text emitterText;
	public string preEmitterString;
	public string postEmitterString;

	public bool updateEffectorsOnChange = false;

	private int _currentEmitor = -1;

	void Awake ()
	{
		foreach (var e in particleEmitters) {
			e.SetActive (false);
		}

		SwitchEmitters ();
	}


	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.N)) {
			SwitchEmitters ();


		}
	}

	private void SwitchEmitters ()
	{
		if (_currentEmitor != -1)
			particleEmitters [_currentEmitor].SetActive (false);
		_currentEmitor = (_currentEmitor + 1) % particleEmitters.Length;
		particleEmitters [_currentEmitor].SetActive (true);

		if (emitterText) {
			emitterText.text = preEmitterString + particleEmitters [_currentEmitor].name + postEmitterString;
		}

		if (updateEffectorsOnChange) {
			CustomParticle.UpdateEffectorList ();
		}
	}
}
