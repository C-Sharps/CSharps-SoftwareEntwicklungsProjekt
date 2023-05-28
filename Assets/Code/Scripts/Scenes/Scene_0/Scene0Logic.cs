using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using TMPro;
using UnityEngine;
using RoslynCSharp;
using System.Linq;

public class Scene0Logic : SceneLogic
{
    GameObject[] robots;
    public void Update()
    {
        // ToDo: Not performant, should be done with events
        robots = GameObject.FindGameObjectsWithTag("Player");
        if (robots.Any(obj => obj != null) && lessonObjectives[0].isCompleted == false)
        {
            CompleteObjective(0);
        }

        if (lessonObjectives[1].isCompleted == false && robots.Any(obj => obj.GetComponentsInChildren<MeshRenderer>()[5].material.color == Color.blue))
        {
            CompleteObjective(1);
        }
    }
}
