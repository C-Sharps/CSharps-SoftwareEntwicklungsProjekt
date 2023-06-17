using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using Code.Scripts.System.SceneManager;
using TMPro;
using UnityEngine;
using RoslynCSharp;
using System.Linq;

public class Scene2Logic : MonoBehaviour
{
    GameObject[] boxes;

    private LessonController _controller;

    public void Awake()
    {
        _controller = FindObjectOfType<LessonController>();
    }

    public void Update()
    {
        boxes = GameObject.FindGameObjectsWithTag("Box()");
        if (GameObject.ReferenceEquals( boxes[0], boxes[1]) && _controller.data.lessonObjectives[0].isCompleted == false)
        {
            _controller.CompleteObjective(0);
        }
    }
}
