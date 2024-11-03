using Interact.Actions;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(InteractLever))]
    public class InteractLeverEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        
            GUILayout.Space(10);
            
            var lever = (InteractLever)target;
            if (GUILayout.Button("Reset Lever Type"))
            {
                lever._ResetLeverType();
            }
        }
    }
}
