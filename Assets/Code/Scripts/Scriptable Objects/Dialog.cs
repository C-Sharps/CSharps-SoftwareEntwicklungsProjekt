using UnityEngine;

namespace Code.Scripts
{
    public enum DialogType
    {
        OnStart,
        OnObjectiveComplete, // not implemented yet
        OnObjectiveFail, // not implemented yet
        OnLessonComplete
    }
    
    [CreateAssetMenu(fileName = "Dialog", menuName = "ScriptableObjects/Dialog", order = 1)]
    public class Dialog : ScriptableObject
    {
        [Header("Basic Settings")]
        public string dialogName;
        [TextArea(3, 50)]
        public string dialogText;
        public DialogType dialogType;
        public bool isCompleted;
        
        [Header("Type Settings")]
        public int objectiveIndex;
    }
}