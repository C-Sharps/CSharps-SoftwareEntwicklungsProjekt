/**
 * Author: Stefan Pietzner
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using UnityEngine;
using Code.Scripts;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public static class LessonManager
{
    private static Lesson[] lessons;

    private static Lesson currentLesson;

    private const string mainMenuSceneName = "0 - Main Menu";

    private const string shipDeckSceneName = "1 - Ship Deck";

    static LessonManager () { 
        lessons = Resources.LoadAll("ScriptableObjects/LessonSOs", typeof(Lesson)).Cast<Lesson>().ToArray();

        if (lessons.Length == 0)
        {
            throw new UnityException("Could not load scriptable objects for lesson!");
        }
    }

    public static Lesson GetLesson(int index)
    {
        return lessons[index];
     
    }

    public static Lesson GetLessonByName(string lessonName)
    {
        if (lessonName != null) {
            foreach (Lesson lesson in lessons)
            {
                if (lessonName.Equals(lesson.name))
                {
                    return lesson;
                }
            }
            Debug.LogWarning("Lesson named " + lessonName + " not found!");
        }
        return null;
    }

    public static void SetCurrentLesson(Lesson currentLesson)
    {
        LessonManager.currentLesson = currentLesson;
    }

    public static void LoadLesson(Lesson lesson)
    {
        if (Application.CanStreamedLevelBeLoaded(lesson.name))
        {
            SceneManager.LoadSceneAsync(lesson.name);
        }
        else
        {
            throw new UnityException("Could not load scene " + lesson.name + "!");
        }
    }

    public static void LoadNextLesson()
    {
        if (currentLesson == null)
        {
            Debug.LogWarning("Current lesson not set - cannot load next lesson!");
        }
        else if (currentLesson.nextLesson == 0) {
            Debug.LogWarning("Next lesson not set!");
        }
        else
        {
            SceneManager.LoadScene(
            lessons[currentLesson.nextLesson].name);
        }
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(
            mainMenuSceneName);
    }

    public static void LoadShipDeck()
    {
        SceneManager.LoadScene(
            shipDeckSceneName);
    }
}
