using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using Code.Scripts.System.SceneManager;
using TMPro;
using UnityEngine;
using RoslynCSharp;
using System.Linq;

public class Scene3Logic : MonoBehaviour
{
    GameObject[] boxes;

    private LessonController _controller;

    public void Awake()
    {
        _controller = FindObjectOfType<LessonController>();
    }

    public void Update()
    {
        boxes = GameObject.FindGameObjectsWithTag("Box");
        if (boxes.Length > 2)
        {
            ShrinkAndDestroyBox();
        }

        if (_controller.data.lessonObjectives[0].isCompleted == false)
        {
            _controller.CompleteObjective(0);
        }
    }

    private void ShrinkAndDestroyBox()
    {
        GameObject box = boxes[0];

        if (box.transform.localScale.magnitude > 0.1f)
        {
            float shrinkAmount = 1.0f;

            if (boxes.Length > 3)
            {
                shrinkAmount = 1.5f * boxes.Length;
            }

            Vector3 newScale = box.transform.localScale - new Vector3(shrinkAmount, shrinkAmount, shrinkAmount) * Time.deltaTime;

            newScale = Vector3.Max(newScale, Vector3.zero);

            box.transform.localScale = newScale;
        }
        else
        {
            Destroy(box);
        }
    }
}
