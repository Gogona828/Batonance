using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SerializeField))]
public class ShowProperty : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (!property.isArray) {
            label.text = property.displayName;
        }
        EditorGUI.PropertyField(position, property, label, true);
    }
}
#endif