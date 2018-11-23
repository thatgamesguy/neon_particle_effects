using UnityEngine;
using UnityEditor;
using System.Collections;

namespace PE2D
{
	[CustomEditor (typeof(ParticleEffector)), CanEditMultipleObjects]
	public class ParticleEffectorEditor : Editor
	{
		private SerializedProperty _effectorType;
		private SerializedProperty _distance;
		private SerializedProperty _rotateDistance;
		private SerializedProperty _force;

		void OnEnable ()
		{
			_effectorType = serializedObject.FindProperty ("effectorType");
			_distance = serializedObject.FindProperty ("distance");
			_rotateDistance = serializedObject.FindProperty ("rotateDistance");
			_force = serializedObject.FindProperty ("force");

		}

		public override void OnInspectorGUI ()
		{
			serializedObject.Update ();

			EditorGUILayout.PropertyField (_effectorType);
			EditorGUILayout.PropertyField (_distance);

			if (_effectorType.enumValueIndex == (int)EffectorType.BlackHole) {
				EditorGUILayout.PropertyField (_rotateDistance);
			}

			EditorGUILayout.PropertyField (_force);




			serializedObject.ApplyModifiedProperties ();
		}
	}
}
