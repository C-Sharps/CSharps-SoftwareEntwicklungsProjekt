using System.Collections.Generic;
using Code.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.System.SceneManager
{
    public class LessonView : MonoBehaviour
    {
        [Header("General")]
        public GameObject editor;
        public GameObject editorTabs;
        public TMP_InputField codeEditorInputField;
        public TextMeshProUGUI codeEditorHighlight;
        public TextMeshProUGUI errorOutput;
        public GameObject console;
        public List<UITab> Tabs = new List<UITab>();
        
        // Objective Window
        [Header("Objectives")]
        private bool _isObjectiveOpen = true;
        public GameObject objectiveContainer;
        public GameObject objectiveWindow;
        public Image objectiveIcon;
        private Vector3 _objectiveClosedPosition = new Vector3(-550f, -105f, 0f);
        private Vector3 _objectiveOpenPosition= new Vector3(-550f, 100f, 0f);
        
        // Settings Window
        [Header("Settings")]
        private bool _isSettingsOpen = false;
        public GameObject settingsContainer;
        public Dropdown fontSizeDropdown;
        public Slider speedSlider;

        [Header("Other Windows")] 
        public GameObject resetWindow;
        public GameObject leaveWindow;

        public void ToggleEditor()
        {
            editor.SetActive(!editor.activeSelf);
            editorTabs.SetActive(!editorTabs.activeSelf);
        }

        public void ToggleReset()
        {
            resetWindow.SetActive(!resetWindow.activeSelf);
        }
        
        public void ToggleLeave()
        {
            leaveWindow.SetActive(!leaveWindow.activeSelf);
        }

        public void ChangeFontSize()
        {
            int fontSize = 14;
            int id = fontSizeDropdown.value;
            switch (id)
            {
                case 0:
                    fontSize = 8;
                    break;
                case 1:
                    fontSize = 11;
                    break;
                case 2:
                    fontSize = 14;
                    break;
                case 3:
                    fontSize = 18;
                    break;
                case 4:
                    fontSize = 22;
                    break;
                case 5:
                    fontSize = 26;
                    break;
            }
            
            codeEditorInputField.textComponent.fontSize = fontSize;
            codeEditorHighlight.fontSize = fontSize;
        }
        
        public void ToggleObjectiveWindow()
        {
            _isObjectiveOpen = !_isObjectiveOpen;
            objectiveWindow.GetComponent<RectTransform>().anchoredPosition =
                _isObjectiveOpen ? _objectiveClosedPosition : _objectiveOpenPosition;
            objectiveIcon.sprite =
                _isObjectiveOpen ? Resources.Load<Sprite>("Icons/up") : Resources.Load<Sprite>("Icons/down");
        }
        
        public void ToggleSettingsWindow()
        {
            settingsContainer.SetActive(!settingsContainer.activeSelf);
        }
        
        public void SetEditorText(string text)
        {
            codeEditorHighlight.text = text;
            codeEditorInputField.text = text;
        }
    }
}