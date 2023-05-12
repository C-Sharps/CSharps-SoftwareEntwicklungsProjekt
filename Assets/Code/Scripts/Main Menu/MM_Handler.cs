using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MM_Handler : MonoBehaviour
{ 
    public GameObject PlanetParent;
  
    void Start()
    {
      
        // set the button functions
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(StartGame);
        transform.GetChild(3).GetComponent<Button>().onClick.AddListener(Application.Quit);

        if (PlanetParent == null)
        {
            PlanetParent = GameObject.FindGameObjectWithTag("Planets").gameObject;
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
    
    private void StartGame()
    {
        // load the ship deck scene
        SceneManager.LoadScene("1 - Ship Deck");
    }
}
