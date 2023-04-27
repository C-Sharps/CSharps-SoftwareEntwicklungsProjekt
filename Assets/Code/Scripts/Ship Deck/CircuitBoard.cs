using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBoard : MonoBehaviour
{ 
    public GameObject circuitBoardInterface;

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
            }
        }
    }
    
    // Function for the close button on the circuit board interface
    public void CloseCircuitBoard()
    {
        circuitBoardInterface.SetActive(false);
    }
}
