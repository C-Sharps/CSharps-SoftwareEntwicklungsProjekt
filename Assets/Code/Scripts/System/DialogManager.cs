using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // Dialog System
    [SerializeField]
    public List<Dialog> dialogs = new List<Dialog>();

    private Dialog _currentDialog;
    private GameObject _dialogBox;
    private TextMeshProUGUI _dialogTitle;
    private TextMeshProUGUI _dialogText;
    private List<string> _splitText = new List<string>();
    private int _currentTextIndex;
    private Button _prevButton;
    private Button _nextButton;
    private Button _closeButton;

    private void Start()
    {
        // Setup Interface Variables
        Transform canvas = FindObjectOfType<Canvas>().transform;
        _dialogBox = Instantiate(Resources.Load<GameObject>("Prefabs/Dialog"), canvas);
        _dialogTitle = _dialogBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _dialogText = _dialogBox.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _prevButton = _dialogBox.transform.GetChild(3).GetComponent<Button>();
        _nextButton = _dialogBox.transform.GetChild(4).GetComponent<Button>();
        _closeButton = _dialogBox.transform.GetChild(5).GetComponent<Button>();
        
        _nextButton.onClick.AddListener(NextPage);
        _prevButton.onClick.AddListener(PrevPage);
        _closeButton.onClick.AddListener(CloseDialog);
        
        // Try to Setup first dialog
        if (_currentDialog == null)
        {
            foreach (var dialog in dialogs)
            {
                if (dialog.dialogType == DialogType.OnStart)
                {
                    SetDialog(dialog);
                    break;
                }
            }
        }
    }

    private static List<string> GetChunks(string value, int chunkSize)
    {
        List<string> triplets = new List<string>();
        while (value.Length > chunkSize)
        {
            triplets.Add(value.Substring(0, chunkSize));
            value = value.Substring(chunkSize);
        }
        if (value != "")
            triplets.Add(value);
        return triplets;
    }
    
    private void CloseDialog()
    {
        _dialogBox.SetActive(false);
        _currentDialog = null;
    }

    private void SetDialog(Dialog dialog)
    {
        _dialogBox.SetActive(true);
        _currentDialog = dialog;
        
        // Reset Variables
        _nextButton.interactable = false;
        _prevButton.interactable = false;
        _currentTextIndex = 0;
        _splitText.Clear();
            
        _dialogTitle.text = _currentDialog.dialogName;

        if (_currentDialog.dialogText.Length > 770)
        {
            Debug.Log("Wowie");
            _splitText = GetChunks(_currentDialog.dialogText, 770);
            _dialogText.text = _splitText[0];
            _nextButton.interactable = true;
        }
        else
        {
            _dialogText.text = _currentDialog.dialogText;
        }

        dialog.isCompleted = true;
    }

    private void NextPage()
    {
        _currentTextIndex++;
        if (_splitText[_currentTextIndex] != null)
            _dialogText.text = _splitText[_currentTextIndex];

        if (_currentTextIndex == _splitText.Count - 1)
            _nextButton.interactable = false;
        
        _prevButton.interactable = true;
    }

    private void PrevPage()
    {
        if (_currentTextIndex == 0) return;
        _currentTextIndex--;
        
        if (_splitText[_currentTextIndex] != null)
            _dialogText.text = _splitText[_currentTextIndex];

        if (_currentTextIndex == 0)
            _prevButton.interactable = false;
        
        _nextButton.interactable = true;
    }
}
