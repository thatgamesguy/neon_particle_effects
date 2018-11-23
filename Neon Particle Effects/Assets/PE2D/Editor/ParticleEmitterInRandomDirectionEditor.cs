using UnityEngine;
using UnityEditor;
using System.Collections;

namespace PE2D
{
	[CustomEditor (typeof(ParticleEmitterInRandomDirection)), CanEditMultipleObjects]
	public class ParticleEmitterInRandomDirectionEditor : Editor
	{
		private SerializedProperty _timeBetweenProjectileRelease;
		private SerializedProperty _initialScale;
		private SerializedProperty _particlesEnabled;
		private SerializedProperty _duration;
		private SerializedProperty _velocityDampener;
		private SerializedProperty _lengthMultiplier;
		private SerializedProperty _wrapAround;

		private SerializedProperty _randomColour;
		private SerializedProperty _particleColour;

		private SerializedProperty _clampMinLength;
		private SerializedProperty _minLength;

		private SerializedProperty _clampMaxLength;
		private SerializedProperty _maxLength;

		private SerializedProperty _removeWhenVelocityReachesThreshold;
		private SerializedProperty _customVelocityThreshold;

		private SerializedProperty _removeWhenAlphaReachesThreshold;
		private SerializedProperty _customAlphaThreshold;


		void OnEnable ()
		{
			_timeBetweenProjectileRelease = serializedObject.FindProperty ("timeBetweenProjectileRelease");
			_initialScale = serializedObject.FindProperty ("initialScale");
			_particlesEnabled = serializedObject.FindProperty ("particlesEnabled");
			_duration = serializedObject.FindProperty ("duration");
			_velocityDampener = serializedObject.FindProperty ("velocityDampener");
			_lengthMultiplier = serializedObject.FindProperty ("lengthMultiplier");
			_wrapAround = serializedObject.FindProperty ("wrapAround");

			_randomColour = serializedObject.FindProperty ("randomColour");
			_particleColour = serializedObject.FindProperty ("particleColour");

			_clampMinLength = serializedObject.FindProperty ("clampMinLength");
			_minLength = serializedObject.FindProperty ("minLength");

			_clampMaxLength = serializedObject.FindProperty ("clampMaxLength");
			_maxLength = serializedObject.FindProperty ("maxLength");

			_removeWhenVelocityReachesThreshold = serializedObject.FindProperty ("removeWhenVelocityReachesThreshold");
			_customVelocityThreshold = serializedObject.FindProperty ("customVelocityThreshold");

			_removeWhenAlphaReachesThreshold = serializedObject.FindProperty ("removeWhenAlphaReachesThreshold");
			_customAlphaThreshold = serializedObject.FindProperty ("customAlphaThreshold");
		}
	
		public override void OnInspectorGUI ()
		{
			serializedObject.Update ();

			EditorGUILayout.PropertyField (_particlesEnabled);
			EditorGUILayout.PropertyField (_timeBetweenProjectileRelease);
			EditorGUILayout.PropertyField (_duration);
			EditorGUILayout.PropertyField (_wrapAround);
			EditorGUILayout.PropertyField (_velocityDampener);
			EditorGUILayout.PropertyField (_lengthMultiplier);
			EditorGUILayout.PropertyField (_initialScale);

			EditorGUILayout.PropertyField (_randomColour);
			EditorGUI.indentLevel++;
			if (!_randomColour.boolValue) {
				EditorGUILayout.PropertyField (_particleColour);
			}
			EditorGUI.indentLevel--;

			EditorGUILayout.PropertyField (_clampMinLength);
			EditorGUI.indentLevel++;
			if (_clampMinLength.boolValue) {
				EditorGUILayout.PropertyField (_minLength);
			}
			EditorGUI.indentLevel--;

			EditorGUILayout.PropertyField (_clampMaxLength);
			EditorGUI.indentLevel++;
			if (_clampMaxLength.boolValue) {
				EditorGUILayout.PropertyField (_maxLength);
			}
			EditorGUI.indentLevel--;

			EditorGUILayout.PropertyField (_removeWhenVelocityReachesThreshold);
			EditorGUI.indentLevel++;
			if (_removeWhenVelocityReachesThreshold.boolValue) {
				EditorGUILayout.PropertyField (_customVelocityThreshold);
			}
			EditorGUI.indentLevel--;

			EditorGUILayout.PropertyField (_removeWhenAlphaReachesThreshold);
			EditorGUI.indentLevel++;
			if (_removeWhenAlphaReachesThreshold.boolValue) {
				EditorGUILayout.PropertyField (_customAlphaThreshold);
			}
			EditorGUI.indentLevel--;
			
			serializedObject.ApplyModifiedProperties ();
		}
	}
}
