/**
 * Author: Stefan Pietzner
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using UnityEngine;

namespace Code.Scripts { 
    
    [CreateAssetMenu(menuName ="ScriptableObjects/Lesson")]
    public class Lesson : ScriptableObject
    {
        public string lessonName;
        [TextArea(3, 50)]
        public string description;
        public int order;
        // Defines the lesson coming after this lesson.
        // Used to skip lessons which are not finished yet.
        public int nextLesson;
        public bool isUnlocked;
        public bool isCompleted;
    }
}