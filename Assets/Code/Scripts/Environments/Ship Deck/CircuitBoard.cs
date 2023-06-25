using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CircuitBoard : MonoBehaviour
{ 
    public GameObject circuitBoardInterface;
    public GameObject returnButton;
    
    void Update()
    {
        // check if the circuit board was clicked on
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // if object was clicked on, open circuit board interface
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                circuitBoardInterface.SetActive(true);
                returnButton.SetActive(false);
            }
        }
    }
    
    // Function for the close button on the circuit board interface
    public void CloseCircuitBoard()
    {
        circuitBoardInterface.SetActive(false);
        returnButton.SetActive(true);
    }

    public void ReturnToMain()
    {
        Application.LoadLevel("0 - Main Menu");
    }

    void OnMouseOver()
    {
        GetComponent<MeshRenderer>().material =
            Resources.Load<Material>("Materials/Terminal_Hover");  // enable emission on the circuit board
    }
    
    void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material =
            Resources.Load<Material>("Materials/Terminal");  // disable emission on the circuit board
    }
}
