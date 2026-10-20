using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UnitComponent))]
public sealed class UnitComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.Space();

        using (new EditorGUI.DisabledScope(!Application.isPlaying))
        {
            if (GUILayout.Button("Debug: Restore Health"))
            {
                var unit = (UnitComponent)target;
                Undo.RecordObject(unit, "Restore Unit Health");
                unit.DebugRestoreHealth();
                EditorUtility.SetDirty(unit);
            }
        }
    }
}
