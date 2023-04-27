using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLamp : MonoBehaviour
{
    private Vector3[] originalPositions; // store original positions of child objects
    private Vector3[] targetPositions; // store target positions of child objects
    private bool isMovingDown = false; // flag to check if objects are moving down
    private float timeElapsed = 0f; // track time elapsed for lerp
    private int clickCount = 0; // keeps track of the number of times the object was clicked on
    private bool secretUnlocked = false; // rgb secret unlocked

    private void Start()
    {
        // get original positions of child objects
        originalPositions = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            originalPositions[i] = transform.GetChild(i).position;
        }

        // get target positions of child objects
        targetPositions = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            targetPositions[i] = originalPositions[i];
            targetPositions[i].y -= 0.1f;
        }
    }

    private void Update()
    {
        // check if object was clicked on
        if (Input.GetMouseButtonDown(0) && !secretUnlocked)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // if object was clicked on, move it down
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                clickCount++;

                if (clickCount > 2)
                {
                    secretUnlocked = true;
                }
            }
        }

        if (secretUnlocked)
        {
            // change child material color to create an rainbow color effect over time
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i == 0)
                {
                    transform.GetChild(i).GetComponent<Light>().color = Color.HSVToRGB((Time.time * 0.1f) % 1, 1, 1);
                }
                else
                {
                    transform.GetChild(i).GetComponent<MeshRenderer>().material.SetColor("_EmissionColor",
                        Color.HSVToRGB((Time.time * 0.1f) % 1, 1, 1));
                }
            }
        }


        if (isMovingDown)
        {
            // move child objects down
            for (int i = 0; i < transform.childCount; i++)
            {
                Vector3 childPosition = transform.GetChild(i).position;
                childPosition.y -= 0.1f * Time.deltaTime;
                transform.GetChild(i).position = childPosition;
            }

            timeElapsed += Time.deltaTime;

            if (timeElapsed >= 1f) // reached bottom
            {
                isMovingDown = false;
                timeElapsed = 0f;
            }
        }
        else
        {
            // move child objects back to original positions
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).position = Vector3.Lerp(targetPositions[i], originalPositions[i], timeElapsed);
            }

            timeElapsed += Time.deltaTime;

            if (timeElapsed >= 1f) // reached top
            {
                isMovingDown = true;
                timeElapsed = 0f;
            }
        }
    }
}
