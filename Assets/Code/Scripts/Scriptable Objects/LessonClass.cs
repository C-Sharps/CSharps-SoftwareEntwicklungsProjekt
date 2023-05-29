using UnityEditor;
using UnityEngine;

namespace Code.Scripts
{
    [CreateAssetMenu(fileName = "LessonClass", menuName = "ScriptableObjects/LessonClass", order = 1)]
    public class LessonClass : ScriptableObject
    {
        public string className;
        [TextArea(3, 50)]
        public string classSource;
        public bool interactable;
    }
}