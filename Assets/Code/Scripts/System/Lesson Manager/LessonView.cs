using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.System.SceneManager
{
    public class LessonView : MonoBehaviour
    {
        public TMP_InputField codeEditorInputField;
        public TextMeshProUGUI codeEditorHighlight;
        public GameObject objectiveContainer;
        public TextMeshProUGUI errorOutput;
        public GameObject console;
        
        private void Awake()
        {
            if (codeEditorInputField == null)
                codeEditorInputField = GameObject.FindGameObjectWithTag("Editor_InputField").GetComponent<TMP_InputField>();
            
            if (codeEditorHighlight == null)
                codeEditorHighlight = GameObject.FindGameObjectWithTag("HL_Text").GetComponent<TextMeshProUGUI>();
            
            if (objectiveContainer == null)
                objectiveContainer = GameObject.FindGameObjectWithTag("Objective_Container");
            
            if (errorOutput == null)
                errorOutput = transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
            
            if (console == null)
                console = transform.GetChild(5).gameObject;
        }
    }
}