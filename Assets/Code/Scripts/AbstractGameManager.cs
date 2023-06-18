/**
 * Author: Stefan Pietzner
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class AbstractGameManager : MonoBehaviour
{
    // Use this method to assert that the lession was successfully completed by the player
    public abstract bool AssertLessonTargetComplete();

    // This method should be triggered by the "Run" button in the scene UI
    public void PlayLesson()
    {
        ExecutePlayerCode();

        if (AssertLessonTargetComplete())
        {
            OnLessonComplete();
        }
        else
        {
            OnLessonFailed();
        }
    }

    protected void ExecutePlayerCode()
    {
        Debug.Log("In ExecutePlayerCode()");
    }

    private void OnLessonComplete()
    {
        Debug.Log("In OnLessonComplete()");
    }

    private void OnLessonFailed()
    {
        Debug.Log("In OnLessonFailed()");
    }
}
