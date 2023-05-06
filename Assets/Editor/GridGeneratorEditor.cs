using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;



/*  Custom editor for the GridGenerator
 */
public class GridGeneratorEditor : EditorWindow
{

    public VisualTreeAsset gridEditorInspectorXML;

    public void CreateGUI()
    {
        VisualElement gridEditorInspector = new VisualElement();
        gridEditorInspectorXML.CloneTree(gridEditorInspector);
    }

    [MenuItem("Tools/Grid Generator")]
    public static void ShowEditor()
    {
        EditorWindow window = GetWindow<GridGeneratorEditor>();
        window.titleContent = new UnityEngine.GUIContent("Grid Generator");
    }
}
