using System;
using System.Collections.Generic;
using RoslynCSharp;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Code.Scripts
{
    public class SceneLogic : MonoBehaviour
    {
        public List<LessonClass> lessonClasses = new List<LessonClass>();
        private List<LessonClass> _lessonClassCopy = new List<LessonClass>();
        public List<LessonObjective> lessonObjectives = new List<LessonObjective>();
        public List<LessonObjective> LessonObjectivesCopy = new List<LessonObjective>();
        
        private int _currentTab = 999;
        private TMP_InputField _codeEditorInputField;
        private TextMeshProUGUI _codeEditorHighlight;
        private GameObject _objectiveContainer;
        private TextMeshProUGUI _errorOutput;
        private GameObject _console;


        private ScriptDomain _domain;
        public AssemblyReferenceAsset[] assemblyReferences;

        private void Start()
        {
            foreach (var lessonClass in lessonClasses)
            {
                _lessonClassCopy.Add(Instantiate(lessonClass));
            }

            foreach (var lessonObjective in lessonObjectives)
            {
                LessonObjectivesCopy.Add(Instantiate(lessonObjective));
            }
            
            _objectiveContainer = GameObject.FindGameObjectWithTag("Objective_Container");
            
            // Hide UI Button
            transform.GetChild(4).GetComponent<Button>().onClick.AddListener(ToggleInterface);
            
            // Run Script Button
            transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ExecuteSource);
            
            // Console
            _console = transform.GetChild(5).gameObject;
            transform.GetChild(5).GetComponentInChildren<Button>().onClick.AddListener(ToggleConsole);
            _errorOutput = transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
            
            
            foreach (var lessonClass in _lessonClassCopy)
            {
                // Spawn a new tab for each class in the lesson
                var newTab = Instantiate(Resources.Load<GameObject>("Prefabs/TabClass"), transform.GetChild(1));
                newTab.GetComponentInChildren<TextMeshProUGUI>().text = lessonClass.className;
                newTab.GetComponent<Button>().onClick.AddListener(() => OnTabClick(_lessonClassCopy.IndexOf(lessonClass)));
            }
            
            foreach (var lessonObjective in LessonObjectivesCopy)
            {
                var newObjective = Instantiate(Resources.Load<GameObject>("Prefabs/Objective"), _objectiveContainer.transform);
                newObjective.GetComponent<TextMeshProUGUI>().text = lessonObjective.objectiveDescription;
                // We want to keep the font color of the first objective white to indicate that it is the current objective
                if (LessonObjectivesCopy.IndexOf(lessonObjective) == 0) continue;
                
                newObjective.GetComponent<TextMeshProUGUI>().color = Color.gray;
            }

            _codeEditorInputField = GameObject.FindGameObjectWithTag("Editor_InputField").GetComponent<TMP_InputField>();
            _codeEditorHighlight = GameObject.FindGameObjectWithTag("HL_Text").GetComponent<TextMeshProUGUI>();
            
            _domain = ScriptDomain.CreateDomain("RobotCode", true);
            // Add assembly references
            foreach (AssemblyReferenceAsset reference in assemblyReferences)
                _domain.RoslynCompilerService.ReferenceAssemblies.Add(reference);

            OnTabClick(0);
        }

        private void ToggleInterface()
        {
            // change the active state of every other interface element
            foreach (Transform child in transform)
            {
                if (child.name == "UI_Toggle") continue;
                child.gameObject.SetActive(!child.gameObject.activeSelf);
            }
        }

        private void ExecuteSource()
        {
            ScriptType type = _domain.CompileAndLoadMainSource(_codeEditorInputField.text, ScriptSecurityMode.UseSettings, assemblyReferences);
            
            if (type == null)
            {
                if (!_console.activeSelf) ToggleConsole();
                _errorOutput.text = _domain.RoslynCompilerService.LastCompileResult.Errors[0].ToString();
                return;
            }
            
            type.CreateInstance(gameObject);
        }

        private void ToggleConsole()
        {
            _console.SetActive(!_console.activeSelf);
        }

        public void CompleteObjective(int id)
        {
            LessonObjectivesCopy[0].isCompleted = true;

            if (_objectiveContainer.transform.GetChild(id) != null)
            {
                _objectiveContainer.transform.GetChild(id).GetComponent<TextMeshProUGUI>().fontStyle =
                    FontStyles.Strikethrough;
                _objectiveContainer.transform.GetChild(id).GetComponent<TextMeshProUGUI>().color = Color.gray;
            }
         
            
            if (_objectiveContainer.transform.GetChild(id + 1) != null)
                _objectiveContainer.transform.GetChild(id + 1).GetComponent<TextMeshProUGUI>().color = Color.white;
            
            if (LessonObjectivesCopy.Count == id) OnCompleteLesson();
        }

        private void OnCompleteLesson()
        {
            // ToDo: Implement functionality to move to the next lesson
        }

        private void OnTabClick(int id)
        {
            if (_currentTab == id) return;

            if (_currentTab < _lessonClassCopy.Count)
            {
                if (_lessonClassCopy[_currentTab].interactable)
                {
                    // Save the changed source of the current tab before changing classes.
                    _lessonClassCopy[_currentTab].classSource = _codeEditorInputField.text;
                }
            }
            
            // Set the current tab to the new tab
            _currentTab = id;

            // Set the text of the code editor to the source of the new tab
            _codeEditorInputField.text = lessonClasses[_currentTab].classSource;
            _codeEditorHighlight.text = lessonClasses[_currentTab].classSource;
            _codeEditorInputField.interactable = lessonClasses[_currentTab].interactable;
            
            // Set the button state to selected.
            transform.GetChild(1).GetChild(_currentTab).GetComponent<Button>().Select();
        }
    }
}