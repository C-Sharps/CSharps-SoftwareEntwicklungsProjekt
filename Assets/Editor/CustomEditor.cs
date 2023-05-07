using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class CustomEditor : EditorWindow
{
    private DropdownField _primitiveType;
    private TextField _textField;
    private Toggle _isActiveToggle;
    private Button _createButton;

    [MenuItem("Spawner/Primitive Spawner")]
    public static void ShowWindow()
    {
        var window = GetWindow<CustomEditor>();
        var icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Editor/Images/gear.png");
        window.titleContent = new GUIContent("Primitive Spawner", icon);
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        var root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/CustomEditor.uxml");
        var labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        /*// A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/CustomEditor.uss");
        root.styleSheets.Add(styleSheet);
        */

        // Getting the UI element by name needs type cast
        _primitiveType = (DropdownField)rootVisualElement.Query("primitiveSelector").First();

        // Getting the UI element by type needs to be filtered inorder to get what we want
        _textField = rootVisualElement.Query<TextField>().First();

        // Getting the UI element by type and name
        _isActiveToggle = rootVisualElement.Query<Toggle>("IsActive");
        _createButton = rootVisualElement.Query<Button>("create");
        _createButton.clicked += CreatePrimitive;
    }

    private void CreatePrimitive()
    {
        var primitiveType = Enum.Parse<PrimitiveType>(_primitiveType.choices[_primitiveType.index], true);
        var created = GameObject.CreatePrimitive(primitiveType);
        created.transform.position = Vector3.zero;
        created.name = _textField.text == "" ? primitiveType.ToString() : _textField.text;
        created.SetActive(_isActiveToggle.value);
    }
}
