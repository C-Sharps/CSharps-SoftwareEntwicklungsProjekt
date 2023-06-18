/**
 * Author: Robin Intrieri
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using Code.Scripts.System.SceneManager;
using Code.Scripts.UI;
using RoslynCSharp;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using UnityEngine.SceneManagement;


    [RequireComponent(typeof(LessonData), typeof(LessonView))]
    public class LessonController : MonoBehaviour
    {
        public LessonData data;
        public LessonView view;
        
        // create event for OnExecuteCode
        public event Action OnExecuteCode;
        public event Action OnCompleteLesson;

        private int _currentTab = 999;
        private void Start()
        {
            // Set the current lesson to this lesson
            LessonManager.SetCurrentLesson(LessonManager.GetLessonByName(SceneManager.GetActiveScene().name));

            if (data == null)
                FindObjectOfType<LessonData>();

            if (view == null)
                FindObjectOfType<LessonView>();
            
            foreach (var lessonClass in data.lessonClasses)
            {
                // Spawn a new tab for each class in the lesson
                var newTab = Instantiate(Resources.Load<GameObject>("Prefabs/TabClass"), transform.GetChild(1));
                newTab.GetComponentInChildren<TextMeshProUGUI>().text = lessonClass.className.Replace(".class", ".cs");
                newTab.GetComponent<Button>().onClick.AddListener(() => OnTabClick(data.lessonClasses.IndexOf(lessonClass), newTab.GetComponent<UITab>()));
                view.Tabs.Add(newTab.GetComponent<UITab>());
            }
            
            foreach (var lessonObjective in data.lessonObjectives)
            {
                var newObjective = Instantiate(Resources.Load<GameObject>("Prefabs/Objective"), view.objectiveContainer.transform);
                newObjective.GetComponent<TextMeshProUGUI>().text = "- " + lessonObjective.objectiveDescription;
                // We want to keep the font color of the first objective white to indicate that it is the current objective
                if (data.lessonObjectives.IndexOf(lessonObjective) == 0) continue;
                
                newObjective.GetComponent<TextMeshProUGUI>().color = Color.gray;
            }
            
            OnTabClick(0, view.Tabs[0]);
        }
        
        private void ToggleInterface()
        {
            // change the active state of every other interface element
            foreach (Transform child in transform)
            {
                if (child.name == "UI_Toggle" || child.name == "Dialog(Clone)" || child.name == "Console" || child.name == "Objectives") continue;
                child.gameObject.SetActive(!child.gameObject.activeSelf);
            }
        }
         
        private void ToggleDialog()
        {
            // change the active state of the dialog component
            transform.GetChild(7).gameObject.SetActive(true);
        }

        private void ExecuteSource()
        {
            ScriptType type = data.domain.CompileAndLoadMainSource(view.codeEditorInputField.text, ScriptSecurityMode.UseSettings, data.assemblyReferences);
            OnExecuteCode?.Invoke();
            if (type == null)
            {
                if (!view.console.activeSelf) ToggleConsole();
                view.errorOutput.text = data.domain.RoslynCompilerService.LastCompileResult.Errors[0].ToString();
                return;
            }
            
            type.CreateInstance(gameObject);
        }

        public void ChangeGameSpeed()
        {
            Time.timeScale = (float)view.speedSlider.value;
        }
        
        public void LeaveLesson()
        {
            SceneManager.LoadScene("1 - Ship Deck");
        }

        public void ResetScene()
        {
            // reload scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
         
            if ((id + 1) < data.lessonObjectives.Count)
                view.objectiveContainer.transform.GetChild(id + 1).GetComponent<TextMeshProUGUI>().color = Color.white;

            data.lessonObjectives[id].isCompleted = true;
            
            if (data.IsAllObjectivesComplete())
            {
                view.OnLessonComplete();
                OnCompleteLesson?.Invoke();
            }
        }
        
        private void OnTabClickUI(UITab tab)
        {
            var tabs = FindObjectsByType<UITab>(FindObjectsSortMode.None);
            foreach (var t in tabs)
            {
                if (t == tab) continue;

                if (t.isActive)
                {
                    t.ChangeTabState();
                }
            }
        }
        
        private void OnTabClick(int id, UITab tab)
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
            
            OnTabClickUI(tab);
            // Set the current tab to the new tab
            _currentTab = id;

            // Set the text of the code editor to the source of the new tab
            view.SetEditorText(data.lessonClasses[_currentTab].classSource);
            view.codeEditorInputField.interactable = data.lessonClasses[_currentTab].interactable;
            
            // Set the button state to selected.
            transform.GetChild(1).GetChild(_currentTab).GetComponent<Button>().Select();
        }
    }