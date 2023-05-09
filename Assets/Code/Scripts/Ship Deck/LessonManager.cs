using TMPro;
using UnityEngine;
using UnityEngine.Events;

// Event to handle when a lesson is hovered over
[System.Serializable]
public class LessonHoverEvent : UnityEvent<int, bool> {}

// Struct to hold information about a lesson
[System.Serializable]
public struct Lesson
{
    public string name;
    public string description;
    public string sceneName;
}

public class LessonManager : MonoBehaviour
{
    public LessonHoverEvent onLessonHover;
    public Lesson[] lessons;
    public GameObject lessonHoverUI;
    void Start()
    {
        // Check if the event is null
        onLessonHover ??= new LessonHoverEvent();
        
        onLessonHover.AddListener(OnLessonHover);
    }

    void OnLessonHover(int lessonIndex, bool isHovering)
    {
        // Check if the lesson hover UI is null or if the lesson index is out of range
        if (lessonHoverUI == null) return;
        if (lessonIndex > lessons.Length - 1) return;
        
        // Set the lesson hover UI to active
        lessonHoverUI.SetActive(isHovering);
        lessonHoverUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = lessons[lessonIndex].name;
        lessonHoverUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = lessons[lessonIndex].description;
        
        if (Input.mousePosition.y > Screen.height / 2f)
            lessonHoverUI.transform.position = Input.mousePosition + new Vector3(0, -160, 0);
        else
            lessonHoverUI.transform.position = Input.mousePosition + new Vector3(0, 160, 0);
    }

}
