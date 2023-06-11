using UnityEngine;
using Code.Scripts;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class LessonManager : ScriptableObject
{
    private static Lesson[] lessons;

    private static Lesson currentLesson;

    private const string mainMenuSceneName = "0 - Main Menu";

    private const string shipDeckSceneName = "1 - Ship Deck";

    public static Lesson GetLesson(int index)
    {
        return lessons[index];
    }

    public static Lesson GetLessonByName(string lessonName)
    {
        foreach (Lesson lesson in lessons)
        {
            if (lessonName.Equals(lesson.name)) {
                return lesson;
            }
        }
        Debug.LogWarning("Lesson named " + lessonName + " not found!");
        return null;
    }

    public static void SetCurrentLesson(Lesson currentLesson)
    {
        LessonManager.currentLesson = currentLesson;
    }

    static LessonManager() {

        lessons = Resources.LoadAll("ScriptableObjects/LessonSOs", typeof(Lesson)).Cast<Lesson>().ToArray();

        if (lessons.Length == 0)
        {
            throw new UnityException("Could not load scriptable objects for lesson!");
        }
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
            Debug.LogWarning("Cannot load next lesson - currentLesson is null!");
        }
        else if (currentLesson.order > 0 && currentLesson.order < lessons.Length - 1)
        {
            SceneManager.LoadScene(
            lessons[currentLesson.order].name);
        }
        else
        {
            Debug.LogWarning("Cannot load next lesson - lesson order number invalid (are you in the last lesson?)");
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
