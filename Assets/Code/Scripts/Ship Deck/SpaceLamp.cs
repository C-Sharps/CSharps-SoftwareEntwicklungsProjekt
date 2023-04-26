using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLamp : MonoBehaviour
{
    void Update()
    {
        foreach (Transform child in transform)
        {
            child.transform.position = new Vector3(child.transform.position.x, child.transform.position.y + Mathf.Sin(Time.time) * 0.1f, child.transform.position.z);
        }
       
    }
}
