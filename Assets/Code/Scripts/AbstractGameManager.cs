using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class AbstractGameManager : MonoBehaviour
{
    // Use this method to assert that the lession was successfully completed by the player
    public abstract bool AssertLessionTargetComplete();

    // This method should be triggered by the "Run" button in the scene UI
    protected void PlayLession()
    {
        ExecutePlayerCode();

        if (AssertLessionTargetComplete())
        {
            ShowLessonCompleteWindow();
        }
        else
        {
            ShowLessonFailedWindow();
        }
    }

    private void ExecutePlayerCode()
    {
        Debug.Log("In ExecutePlayerCode()");
    }

    private void ShowLessonCompleteWindow()
    {
        Debug.Log("In ShowLessonCompleteWindow()");
    }

    private void ShowLessonFailedWindow()
    {
        Debug.Log("In ShowLessonFailedWindow()");
    }
}
