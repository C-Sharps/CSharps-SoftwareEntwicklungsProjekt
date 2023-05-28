using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using TMPro;
using UnityEngine;
using RoslynCSharp;

public class Scene1Logic : SceneLogic
{
    // ToDo: Not performant, should be done with events
    GameObject[] robots;
    public void Update()
    {
        // ToDo: Not performant, should be done with events
        robots = GameObject.FindGameObjectsWithTag("Player");
        if (robots.Length >= 10 && lessonObjectives[0].isCompleted == false)
        {
            CompleteObjective(0);
        }
    }
}
