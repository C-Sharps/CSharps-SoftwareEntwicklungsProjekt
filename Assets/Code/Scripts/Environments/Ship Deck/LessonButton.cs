using System.Linq;
using Code.Scripts.System.SaveLoad;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class LessonButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private int _id = 0;
    private LessonHoverEvent onLessonHover;
    public GameObject lessonHoverUI;

    private void Start()
    {
        _id = transform.GetSiblingIndex();
        
        var saveGameManager = FindObjectOfType<SaveGameManager>();
        if (saveGameManager != null)
        {
            if (saveGameManager.IsLessonCompleted(LessonManager.GetLesson(_id).name))
            {
                GetComponent<Image>().color = Color.green;
            }
        }
        
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnClickLesson);

        if (lessonHoverUI == null)
        {
            throw new UnityException("LessonUI not set!");
        }

        // Check if the event is null
        onLessonHover ??= new LessonHoverEvent();
        onLessonHover.AddListener(OnLessonHover);
    }

    private void OnClickLesson()
    {
        try
        {
            LessonManager.LoadLesson(LessonManager.GetLesson(_id));
        }
        catch (UnityException)
        {
            FindFirstObjectByType<CircuitBoard>().ShowLessonNotFoundWindow();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // call the event
        onLessonHover.Invoke(_id, true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // call the event
        onLessonHover.Invoke(_id, false);
    }

    void OnLessonHover(int lessonIndex, bool isHovering)
    {
        // Set the lesson hover UI to active
        lessonHoverUI.SetActive(isHovering);
        // Sets the title of the lesson to the format "n. LessonName"
        lessonHoverUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = lessonIndex + ". "+ LessonManager.GetLesson(lessonIndex).lessonName;
        lessonHoverUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = LessonManager.GetLesson(lessonIndex).description;

        if (Input.mousePosition.y > Screen.height / 2f)
            lessonHoverUI.transform.position = Input.mousePosition + new Vector3(0, -105, 0);
        else
            lessonHoverUI.transform.position = Input.mousePosition + new Vector3(0, 105, 0);
    }
    // Event to handle when a lesson is hovered over
    [System.Serializable]
    
    public class LessonHoverEvent : UnityEvent<int, bool> { }
}
