using System;
using UnityEngine;

namespace Code.Scripts
{
    public class Structures
    {
        [Serializable]
        public class LessonClasses
        {
           public string className;
           [TextArea(3, 10)]
           public string classSource;
           public bool interactable;
        }
        
        [Serializable]
        public class LessonObjective
        {
            public string objectiveDescription;
            public bool isCompleted;
        }
    }
}