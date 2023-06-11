using System;
using UnityEngine;

namespace Code.Scripts { 
    
    [CreateAssetMenu(menuName ="ScriptableObjects/Lesson")]
    public class Lesson : ScriptableObject
    {
        public string lessonName;
        [TextArea(3, 50)]
        public string description;
        public int order;
        public bool isUnlocked;
        public bool isCompleted;
    }
}