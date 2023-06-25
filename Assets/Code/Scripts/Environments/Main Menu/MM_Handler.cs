using System.Collections;
using System.Collections.Generic;
using Code.Scripts.System.SaveLoad;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MM_Handler : MonoBehaviour
{ 
    public GameObject PlanetParent;
    
    [Header("Interface")]
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject ContinueButton;
    public GameObject NewGameWindow;
    public GameObject ExitButton;

    private bool canContinue = false;
  
    void Start()
    {
        if (PlanetParent == null)
        {
            PlanetParent = GameObject.FindGameObjectWithTag("Planets").gameObject;
        }
        
        var saveGameManager = FindObjectOfType<SaveGameManager>();
        if (saveGameManager != null && saveGameManager.saveGame.completedLessons.Count > 0)
        {
            ContinueButton.GetComponent<Button>().interactable = true;
            ContinueButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            canContinue = true;
        }
    }
    
    void Update()
    {
        // slowly change the rotation of main camera over time
        Camera.main.transform.Rotate(0,  1 * Time.deltaTime, 0);

        foreach (Transform t in PlanetParent.transform)
        {
            t.Rotate(0.5f * Time.deltaTime, 1.5f * Time.deltaTime, 0);
        }
    }
    
    public void ToggleOptions()
    {
        MainMenu.SetActive(!MainMenu.activeSelf);
        OptionsMenu.SetActive(!OptionsMenu.activeSelf);
    }

    public void Continue()
    {
        SceneManager.LoadScene("1 - Ship Deck");
        
    }

    public void NewGame()
    {
        if (!canContinue)
        {
            SceneManager.LoadScene("1 - Ship Deck");
        }
        else
        {
            ToggleNewGame();
        }
    }

    public void ToggleNewGame()
    {
        NewGameWindow.SetActive(!NewGameWindow.activeSelf);
        MainMenu.SetActive(!MainMenu.activeSelf);
    }

    public void ResetGame()
    {
        var saveGameManager = FindObjectOfType<SaveGameManager>();
        if (saveGameManager != null)
        {
            saveGameManager.ResetSaveGame();
            SceneManager.LoadScene("1 - Ship Deck");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
