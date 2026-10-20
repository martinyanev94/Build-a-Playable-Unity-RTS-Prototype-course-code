using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelComponent))]
public class LevelComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelComponent levelComponent = (LevelComponent)target;

        EditorGUILayout.Space();
        if (GUILayout.Button("Generate Map"))
        {
            levelComponent.GenerateMap();
        }
    }
}
