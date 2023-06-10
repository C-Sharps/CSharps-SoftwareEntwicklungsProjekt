using System;
using UnityEngine;

namespace Code.Scripts { 
    
    [CreateAssetMenu(menuName ="ScriptableObjects/Lesson Scriptable Object")]
    public class LessonSO : ScriptableObject
    {
        public string sceneName;
        public string description;
        public bool isUnlocked;
        public bool isCompleted;
    }
}