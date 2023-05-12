using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LessonButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private int _id = 0;
    private void Start()
    {
        _id = transform.GetSiblingIndex();
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnClickLesson);
    }

    private void OnClickLesson()
    {
        // call the event
        var scene = FindObjectOfType<LessonManager>().lessons[_id].sceneName;

        if (Application.CanStreamedLevelBeLoaded(scene))
        {
            SceneManager.LoadSceneAsync(scene);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // call the event
        FindObjectOfType<LessonManager>().onLessonHover.Invoke(_id, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // call the event
        FindObjectOfType<LessonManager>().onLessonHover.Invoke(_id, false);
    }
}
