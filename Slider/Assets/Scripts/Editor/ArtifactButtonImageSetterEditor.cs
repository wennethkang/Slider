using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

[CustomEditor(typeof(ArtifactButtonImageSetter))]
public class ArtifactButtonImageSetterEditor : Editor
{
    private ArtifactButtonImageSetter _target;

    private void OnEnable()
    {
        _target = (ArtifactButtonImageSetter)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Find/Fill Images References"))
        {
            _target.FindImagesList();
        }

        if (GUILayout.Button("Update Images"))
        {
            _target.UpdateImages();
        }
    }
}
