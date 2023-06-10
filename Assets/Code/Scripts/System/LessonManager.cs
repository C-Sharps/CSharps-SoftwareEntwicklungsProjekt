using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Code.Scripts;
using System.Linq;

public class LessonManager : MonoBehaviour
{
    public Lesson[] lessons;

    void Awake() { 

        lessons = Resources.LoadAll("ScriptableObjects/LessonSOs", typeof(Lesson)).Cast<Lesson>().ToArray();

        if (lessons.Length == 0)
        {
            throw new UnityException("Could not load scriptable objects for lesson!");
        }
    }
}
