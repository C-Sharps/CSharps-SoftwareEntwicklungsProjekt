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
        /// <summary>
        /// Defines the lesson coming after this lesson.
        /// </summary>
        /// <remarks>ATTENTION: Start counting from 0, since <see cref="LessonManager.LoadNextLesson"/>
        /// gets the lesson from the <see cref="LessonManager.lessons"/> array!<br/>
        /// The number in the lesson name is the correct way to reference them.</remarks>
        // Used to skip lessons which are not finished yet.
        public int nextLesson;
        public bool isUnlocked;
        public bool isCompleted;
    }
}