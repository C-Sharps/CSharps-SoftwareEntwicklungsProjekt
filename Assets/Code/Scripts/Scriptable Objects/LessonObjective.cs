/**
 * Author: Robin Intrieri
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using UnityEngine;

namespace Code.Scripts
{
    [CreateAssetMenu(fileName = "LessonObjective", menuName = "ScriptableObjects/LessonObjective", order = 1)]
    public class LessonObjective : ScriptableObject
    {
        public string objectiveDescription;
        public bool isCompleted;
    }
}