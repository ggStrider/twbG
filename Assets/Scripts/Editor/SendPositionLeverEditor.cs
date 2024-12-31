using UnityEngine;
using UnityEditor;

using Interact.Actions.Strategies.Lever.Tools;

namespace Editor
{
    [CustomEditor(typeof(SendPositionToLever))]
    public class SendPositionLeverEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        
            GUILayout.Space(10);
            
            var lever = (SendPositionToLever)target;
            var color = new Color(0.8f, 0.1f, 0.8f);
            GUI.backgroundColor = color;
            
            if (GUILayout.Button("Set start position"))
            {
            }
            
            var color2 = new Color(0.3f, 0.6f, 0.7f);
            GUI.backgroundColor = color2;
            if (GUILayout.Button("Set end position"))
            {
            }
        }
    }
}
