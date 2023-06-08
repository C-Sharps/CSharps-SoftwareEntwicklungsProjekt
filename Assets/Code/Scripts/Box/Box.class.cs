using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Burst.Intrinsics;

public class Box : MonoBehaviour
{
    // Attribute for the color of the box
    public Color color;

    // Attribute for the weight of the box
    public float weight;

    // Attribute to track if the box is full
    public bool isFull;

    // Attribute for the contents of the box
    public string contents;

    private void Start()
    {
    }

    // Constructor to initialize the attributes of the box
    public Box(Color color, float weight, bool isFull, string contents) 
    {
        var boxi = Instantiate(Resources.Load<GameObject>("Prefabs/Box"), new Vector3(5.75f, 8f, 0f),
            Quaternion.identity);
        boxi.GetComponentsInChildren<MeshRenderer>()[0].material.color = color;
        boxi.transform.Rotate(0f, 180f, 0f);

        var comp = Boxi.AddComponent<Box>();
        
        comp.color = color;
        comp.weight = weight;
        comp.isFull = isFull;
        comp.contents = contents;

        
    }

    public void Update()
    {
    }
}
