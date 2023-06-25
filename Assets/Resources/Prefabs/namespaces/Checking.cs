using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using Code.Scripts.System.SceneManager;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using RoslynCSharp;
using System.Linq;

public class CheckCorrect : MonoBehaviour { 

    public static bool[] Obj = new bool[6];

    private static LessonController _controller;

    public static void CheckCorrectSyntax(string prompt, string input) 
    {
        input = String.Concat(input.Where(c => !Char.IsWhiteSpace(c)));
        
        switch(prompt) {
        case "Objective1":
            Obj[0] = input.Equals("red>blue");
            break;
        case "Objective2":
            Obj[1] = input.Equals("blue<green");
            break;
        case "Objective3":
            Obj[2] = input.Equals("green==yellow");
            break;
        case "Objective4":
            Obj[3] = input.Equals("yellow<=red");
            break;
        case "Objective5":
            Obj[4] = input.Equals("yellow!=blue");
            break;
        case "Objective6":
            Obj[5] = input.Equals("yellow>=black");
            break;
        default:
            _controller = FindObjectOfType<LessonController>();
            _controller.DisplayError("Wrong objective input! Please check syntax!");
            break;
        }
    }

    public static bool GetObjArray(int i)
    {
        return Obj[i];
    }
}

