using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableEvents;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(ScriptableEventBase))]
    public class ScriptableEventEditor : UnityEditor.Editor
    {
        private ScriptableEventBase _target;
        public override void OnInspectorGUI()
        {
            _target = (ScriptableEventBase)target;

            base.OnInspectorGUI();

            
            if (GUILayout.Button("Debug Raise Event"))
            {
                _target.Raise();
            }
            
            

            //GUILayout, does care about positioning
            //GUIEditorLayout
            //EditorGUILayout, doesnt care about positioning, mind the layout suffix
        }
    }
}


