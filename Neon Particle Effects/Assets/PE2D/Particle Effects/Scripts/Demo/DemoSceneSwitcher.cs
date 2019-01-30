using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Switches between demo scenes when enter key pressed.
/// </summary>
public class DemoSceneSwitcher : MonoBehaviour
{

	public int numberOfScenes = 3;
	private int _currentScene = 0;

	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.KeypadEnter) || Input.GetKey ("return")) {
			_currentScene = (_currentScene + 1) % numberOfScenes;
            SceneManager.LoadScene(_currentScene);
		}
	}
}
