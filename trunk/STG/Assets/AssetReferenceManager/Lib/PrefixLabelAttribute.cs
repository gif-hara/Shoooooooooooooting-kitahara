using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PrefixLabelAttribute : PropertyAttribute {

	public string label;

	public PrefixLabelAttribute (string label) {
		this.label = label;
	}
}

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(PrefixLabelAttribute))]
public class PrefixLabelDrawer : PropertyDrawer {

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		PrefixLabelAttribute script = attribute as PrefixLabelAttribute;
		label.text = script.label;
		EditorGUI.PropertyField(position, property, label, true);
	}
}

#endif
