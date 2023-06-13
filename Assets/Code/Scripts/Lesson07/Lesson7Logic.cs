
using Code.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class Lesson7Logic : MonoBehaviour
{
    
    public Robot r;
    public LessonController sceneController;

    void Start()
    {
        sceneController = FindObjectOfType<LessonController>();
        sceneController.OnExecuteCode += OnExecuteCode;
    }

    private void OnExecuteCode()
    {
        if (sceneController.view.codeEditorInputField.textComponent.textInfo.lineCount < 51 && sceneController.data.lessonObjectives[0].isCompleted == false)
        {
            sceneController.CompleteObjective(0);
        }
    }
    
    void Update()
    {
        if (r == null)
            r = GameObject.FindWithTag("Player").GetComponent<Robot>();

        if (r.GetPosition().y > 50 && sceneController.data.lessonObjectives[1].isCompleted == false)
        {
            sceneController.CompleteObjective(1);
        }

        if (r.GetPosition().y > 98 && sceneController.data.lessonObjectives[2].isCompleted == false)
        {
            sceneController.CompleteObjective(2);
        }

    }
    
}
