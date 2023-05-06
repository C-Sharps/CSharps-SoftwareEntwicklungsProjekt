using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorInspector : Editor
{

    public VisualTreeAsset gridGeneratorUXML;

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement gridGeneratorInspector = new VisualElement();
        gridGeneratorUXML.CloneTree(gridGeneratorInspector);
        return gridGeneratorInspector;
    }
}
