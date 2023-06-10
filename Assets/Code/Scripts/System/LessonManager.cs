using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Code.Scripts;
using System.Linq;

// Event to handle when a lesson is hovered over
[System.Serializable]
public class LessonHoverEvent : UnityEvent<int, bool> {}

public class LessonManager : MonoBehaviour
{
    public LessonHoverEvent onLessonHover;
    public Lesson[] lessons;
    public GameObject lessonHoverUI;
    void Awake()
    {
        lessons = Resources.LoadAll("ScriptableObjects/LessonSOs", typeof(Lesson)).Cast<Lesson>().ToArray();

        if (lessons.Length == 0)
        {
            throw new UnityException("Could not load scriptable objects for lesson!");
        }

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
        lessonHoverUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = lessons[lessonIndex].lessonName;
        lessonHoverUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = lessons[lessonIndex].description;
        
        if (Input.mousePosition.y > Screen.height / 2f)
            lessonHoverUI.transform.position = Input.mousePosition + new Vector3(0, -160, 0);
        else
            lessonHoverUI.transform.position = Input.mousePosition + new Vector3(0, 160, 0);
    }

}
