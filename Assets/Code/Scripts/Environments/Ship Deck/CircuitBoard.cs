using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CircuitBoard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    public GameObject circuitBoardInterface;
    public GameObject lessonNotFoundWindow;

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

    public void ShowLessonNotFoundWindow()
    {
        lessonNotFoundWindow.SetActive(true);
    }

    public void CloseLessonNotFoundWindow()
    {
        lessonNotFoundWindow.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION"); // enable emission on the circuit board
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION"); // enable emission on the circuit board
    }
}
