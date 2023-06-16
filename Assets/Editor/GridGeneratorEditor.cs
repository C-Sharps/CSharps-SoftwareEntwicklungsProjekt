/**
 * Author: Stefan Pietzner
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

/*  Custom editor for the GridGenerator
 */
public class GridGeneratorEditor : EditorWindow

{
    private Button gridGeneratorButton;
    private GridGenerator gridGenerator;


    [MenuItem("Tools/Grid Generator")]
    public static void ShowWindow()
        {
            EditorWindow window = GetWindow<GridGeneratorEditor>();
            window.titleContent = new GUIContent("Grid Generator");
        }

    public void CreateGUI()
    {
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/GridEditorLayout.uxml");
        var layout = visualTree.Instantiate();
        rootVisualElement.Add(layout);

        // Initialize a gridGenerator object and 
        gridGenerator = ScriptableObject.CreateInstance<GridGenerator>();
        SerializedObject so = new SerializedObject(gridGenerator);
        BindingExtensions.Bind(rootVisualElement, so);

        // Not used any longer: Binding the rootVisualElement does the trick!
        /*
        gridObject = rootVisualElement.Query<PropertyField>("gridObject");
        gridSizeField = rootVisualElement.Query<Vector2IntField>("gridSizeField");
        originField = rootVisualElement.Query<Vector3Field>("originField");
        tileSpriteField = rootVisualElement.Query<PropertyField>("tileSpriteField");
        cellSizeXField = rootVisualElement.Query<FloatField>("cellSizeXField");
        cellSizeYField = rootVisualElement.Query<FloatField>("cellSizeYField");
        cellSizeZField = rootVisualElement.Query<FloatField>("cellSizeZField");
        orientationField = rootVisualElement.Query<EnumField>("orientationField");
        useGridLabelToggle = rootVisualElement.Query<Toggle>("useGridLabelToggle");
        */
        gridGeneratorButton = rootVisualElement.Query<Button>("gridGeneratorButton");
        gridGeneratorButton.clicked += gridGenerator.GenerateGrid;
    }
}
