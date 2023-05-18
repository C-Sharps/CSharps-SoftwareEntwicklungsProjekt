using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using TMPro;
using UnityEngine;
using RoslynCSharp;

public class Scene1Logic : SceneLogic
{
    
    public void Update()
    {
        // ToDo: Not performant, should be done with events
        var robot = GameObject.FindGameObjectWithTag("Player");
        if (robot != null && lessonObjectives[0].isCompleted == false)
        {
            CompleteObjective(0);
        }
    }
}
