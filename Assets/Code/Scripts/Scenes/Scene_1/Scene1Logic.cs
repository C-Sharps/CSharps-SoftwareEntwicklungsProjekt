using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using Code.Scripts.System.SceneManager;
using TMPro;
using UnityEngine;
using RoslynCSharp;

public class Scene1Logic : MonoBehaviour
{
    // ToDo: Not performant, should be done with events
    GameObject[] robots;

    private LessonController _controller;

    public void Awake()
    {
        _controller = FindObjectOfType<LessonController>();
    }

    public void Update()
    {
        // ToDo: Not performant, should be done with events
        robots = GameObject.FindGameObjectsWithTag("Player");
        if (robots.Length >= 10 && _controller.data.lessonObjectives[0].isCompleted == false)
        {
            _controller.CompleteObjective(0);
        }
    }
}
