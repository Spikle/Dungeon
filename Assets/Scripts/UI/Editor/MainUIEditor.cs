using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Scripts.UI.Editor
{
    [CustomEditor(typeof(MainUI))]
    public class MainUIEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            MainUI mainUI = (MainUI)target;

            base.OnInspectorGUI();

            if (GUILayout.Button("Find Menus"))
            {
                mainUI.FindMenus();
            }
        }
    }
}