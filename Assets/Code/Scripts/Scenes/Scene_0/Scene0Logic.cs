using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using Code.Scripts.System.SceneManager;
using TMPro;
using UnityEngine;
using RoslynCSharp;
using System.Linq;

public class Scene0Logic : MonoBehaviour
{
    GameObject[] robots;

    private LessonController _controller;

    public void Awake()
    {
        _controller = FindObjectOfType<LessonController>();
    }

    public void Update()
    {
        robots = GameObject.FindGameObjectsWithTag("Robot(color)");
        if (robots.Any(obj => obj != null) && _controller.data.lessonObjectives[0].isCompleted == false)
        {
            _controller.CompleteObjective(0);
        }

        if (_controller.data.lessonObjectives[1].isCompleted == false && robots.Any(obj => obj.GetComponentsInChildren<MeshRenderer>()[5].material.color == Color.blue))
        {
            _controller.CompleteObjective(1);
        }
    }
}
