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
    public List<Dialog> pages = new List<Dialog>();

    private Dialog _currentPage;
    private GameObject _dialogBox;
    private TextMeshProUGUI _dialogTitle;
    private TextMeshProUGUI _dialogText;
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
        if (_currentPage == null)
        {
            foreach (var page in pages)
            {
                if (page.dialogType == DialogType.OnStart)
                {
                    SetDialog(page);
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
    }

    private void SetDialog(Dialog page)
    {
        _dialogBox.SetActive(true);
        _currentPage = page;
        
        _prevButton.interactable = false || pages.IndexOf(_currentPage) > 0;
        _nextButton.interactable = false || pages.IndexOf(_currentPage) < pages.Count - 1;

        _dialogTitle.text = page.dialogName;
        _dialogText.text = page.dialogText;
    }

    private void NextPage()
    {
        if (pages.IndexOf(_currentPage) + 1 < pages.Count) { 
            _currentPage = pages[pages.IndexOf(_currentPage) + 1]; 
        }
        
        SetDialog(_currentPage);
    }
    
    private void PrevPage()
    {
        if (pages.IndexOf(_currentPage) - 1 >= 0) { 
            _currentPage = pages[pages.IndexOf(_currentPage) - 1]; 
        }
        
        SetDialog(_currentPage);
    }
}
