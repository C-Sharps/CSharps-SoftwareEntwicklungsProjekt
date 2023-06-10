using System;
using UnityEngine;

namespace Code.Scripts { 
    
    [CreateAssetMenu(menuName ="ScriptableObjects/Lesson")]
    public class Lesson : ScriptableObject
    {
        public string lessonName;
        public string description;
        public bool isUnlocked;
        public bool isCompleted;
    }
}