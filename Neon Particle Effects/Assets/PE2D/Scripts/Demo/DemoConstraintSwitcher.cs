using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using PE2D;

/// <summary>
/// Switches between screen constraints in the demo scene.
/// </summary>
public class DemoConstraintSwitcher : MonoBehaviour
{

	public DemoMouseController mouseController;
	public Text constraintText;

	private Dictionary<int, WrapAroundType> lookUp = new Dictionary<int, WrapAroundType> ();

	private int _currentKey = 0;
	
	void Start ()
	{
		lookUp.Add (0, WrapAroundType.Constrain);
		lookUp.Add (1, WrapAroundType.WrapAround);
		lookUp.Add (2, WrapAroundType.None);
	
		SwitchToCurrentConstraint ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.N)) {
			_currentKey = (_currentKey + 1) % lookUp.Count;
			SwitchToCurrentConstraint ();
		}
	
	}

	private void SwitchToCurrentConstraint ()
	{
		mouseController.wrapAround = lookUp [_currentKey];
		constraintText.text = "[Current Constraint: " + lookUp [_currentKey] + "]";
	}
	
}
