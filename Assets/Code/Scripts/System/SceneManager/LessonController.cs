using Code.Scripts.System.SceneManager;
using RoslynCSharp;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Code.Scripts.System.SceneManager
{
    [RequireComponent(typeof(LessonData), typeof(LessonView))]
    public class LessonController : MonoBehaviour
    {
        public LessonData data;
        public LessonView view;

        private int _currentTab = 999;
        private void Start()
        {
            if (data == null)
                FindObjectOfType<LessonData>();

            if (view == null)
                FindObjectOfType<LessonView>();
            
            // Hide UI Button
            transform.GetChild(4).GetComponent<Button>().onClick.AddListener(ToggleInterface);
            
            // Run Script Button
            transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ExecuteSource);
            
            foreach (var lessonClass in data.lessonClasses)
            {
                // Spawn a new tab for each class in the lesson
                var newTab = Instantiate(Resources.Load<GameObject>("Prefabs/TabClass"), transform.GetChild(1));
                newTab.GetComponentInChildren<TextMeshProUGUI>().text = lessonClass.className;
                newTab.GetComponent<Button>().onClick.AddListener(() => OnTabClick(data.lessonClasses.IndexOf(lessonClass)));
            }
            
            foreach (var lessonObjective in data.lessonObjectives)
            {
                var newObjective = Instantiate(Resources.Load<GameObject>("Prefabs/Objective"), view.objectiveContainer.transform);
                newObjective.GetComponent<TextMeshProUGUI>().text = lessonObjective.objectiveDescription;
                // We want to keep the font color of the first objective white to indicate that it is the current objective
                if (data.lessonObjectives.IndexOf(lessonObjective) == 0) continue;
                
                newObjective.GetComponent<TextMeshProUGUI>().color = Color.gray;
            }
            
            OnTabClick(0);
        }
        
         private void ToggleInterface()
        {
            // change the active state of every other interface element
            foreach (Transform child in transform)
            {
                if (child.name == "UI_Toggle" || child.name == "Dialog(Clone)" || child.name == "Console") continue;
                child.gameObject.SetActive(!child.gameObject.activeSelf);
            }
        }

        private void ExecuteSource()
        {
            ScriptType type = data.domain.CompileAndLoadMainSource(view.codeEditorInputField.text, ScriptSecurityMode.UseSettings, data.assemblyReferences);
            
            if (type == null)
            {
                if (!view.console.activeSelf) ToggleConsole();
                view.errorOutput.text = data.domain.RoslynCompilerService.LastCompileResult.Errors[0].ToString();
                return;
            }
            
            type.CreateInstance(gameObject);
        }

        private void ToggleConsole()
        {
            view.console.SetActive(!view.console.activeSelf);
        }

        public void CompleteObjective(int id)
        {
            data.lessonObjectives[0].isCompleted = true;

            if (view.objectiveContainer.transform.GetChild(id) != null)
            {
                view.objectiveContainer.transform.GetChild(id).GetComponent<TextMeshProUGUI>().fontStyle =
                    FontStyles.Strikethrough;
                view.objectiveContainer.transform.GetChild(id).GetComponent<TextMeshProUGUI>().color = Color.gray;
            }
         
            
            if (view.objectiveContainer.transform.GetChild(id + 1) != null)
                view.objectiveContainer.transform.GetChild(id + 1).GetComponent<TextMeshProUGUI>().color = Color.white;
            
            if (data.lessonObjectives.Count == id) OnCompleteLesson();
        }

        private void OnCompleteLesson()
        {
            // ToDo: Implement functionality to move to the next lesson
        }

        private void OnTabClick(int id)
        {
            if (_currentTab == id) return;

            if (_currentTab < data.lessonClasses.Count)
            {
                if (data.lessonClasses[_currentTab].interactable)
                {
                    // Save the changed source of the current tab before changing classes.
                    data.lessonClasses[_currentTab].classSource = view.codeEditorInputField.text;
                }
            }
            
            // Set the current tab to the new tab
            _currentTab = id;

            // Set the text of the code editor to the source of the new tab
            view.codeEditorInputField.text = data.lessonClasses[_currentTab].classSource;
            view.codeEditorHighlight.text = data.lessonClasses[_currentTab].classSource;
            view.codeEditorInputField.interactable = data.lessonClasses[_currentTab].interactable;
            
            // Set the button state to selected.
            transform.GetChild(1).GetChild(_currentTab).GetComponent<Button>().Select();
        }
    }
}