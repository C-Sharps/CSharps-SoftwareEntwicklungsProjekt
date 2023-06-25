/**
 * Author: Robin Intrieri
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
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
        public GameObject completeWindow;
        public GameObject bottomButtons;
        public Text completeText;
        public GameObject consoleWindow;

        public void ToggleEditor()
        {
            editor.SetActive(!editor.activeSelf);
            editorTabs.SetActive(!editorTabs.activeSelf);
        }

        public void ToggleConsole()
        {
            consoleWindow.SetActive(!consoleWindow.activeSelf);
        }

        public void OnLessonComplete()
        {
            bottomButtons.transform.GetChild(0).gameObject.SetActive(true);
            completeText.text = "Congratulations! You have completed the lesson!";

            foreach (var button in bottomButtons.GetComponentsInChildren<Button>())
            {
                if (button.name == "End Screen") continue;
                
                button.interactable = false;
            }
            
            ToggleCompleteWindow();
        }
        
        public void ToggleCompleteWindow()
        {
            completeWindow.SetActive(!completeWindow.activeSelf);
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