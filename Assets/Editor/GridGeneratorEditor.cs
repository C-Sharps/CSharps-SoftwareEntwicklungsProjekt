using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

/*  Custom editor for the GridGenerator
 */
public class GridGeneratorEditor : EditorWindow

{
    private PropertyField gridObject;
    private Vector2IntField gridSizeField;
    private Vector3Field originField;
    private PropertyField tileSpriteField;
    private FloatField cellSizeXField;
    private FloatField cellSizeYField;
    private FloatField cellSizeZField;
    private EnumField orientationField;
    private Toggle useGridLabelToggle;
    private Button gridGeneratorButton;

    private GridGenerator gridGenerator;

    void OnAwake()
    {
        gridGenerator ??= new GridGenerator();
    }

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

        gridObject = rootVisualElement.Query<PropertyField>("gridObject");
        gridSizeField = rootVisualElement.Query<Vector2IntField>("gridSizeField");
        originField = rootVisualElement.Query<Vector3Field>("originField");
        tileSpriteField = rootVisualElement.Query<PropertyField>("tileSpriteField");
        cellSizeXField = rootVisualElement.Query<FloatField>("cellSizeXField");
        cellSizeYField = rootVisualElement.Query<FloatField>("cellSizeYField");
        cellSizeZField = rootVisualElement.Query<FloatField>("cellSizeZField");
        orientationField = rootVisualElement.Query<EnumField>("orientationField");
        useGridLabelToggle = rootVisualElement.Query<Toggle>("useGridLabelToggle");
        gridGeneratorButton = rootVisualElement.Query<Button>("gridGeneratorButton");
        gridGeneratorButton.clicked += Generate;
    }

    private void Generate()
    {
        gridGenerator.GenerateGrid();
    }
}
