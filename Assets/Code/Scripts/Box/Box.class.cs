using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    // Constructor to initialize the attributes of the box
    public Box(Color color, float weight, bool isFull, string contents)
    {
        this.color = color;
        this.weight = weight;
        this.isFull = isFull;
        this.contents = contents;

        CreateBox();
    }

    public Box(string input)
    {
        // Parse the input and assign values to attributes (assuming you're doing it here)
        // ...

        CreateBox();
    }

    public Box(int input)
    {
        // Parse the input and assign values to attributes (assuming you're doing it here)
        // ...

        CreateBox();
    }

    public Box(bool input)
    {
        // Parse the input and assign values to attributes (assuming you're doing it here)
        // ...

        CreateBox();
    }

    private void CreateBox()
    {
        var box = Instantiate(Resources.Load<GameObject>("Prefabs/Box"), new Vector3(5.75f, 8f, 0f),
            Quaternion.identity);
        box.GetComponentsInChildren<MeshRenderer>()[0].material.color = color;
        box.transform.Rotate(0f, 180f, 0f);

        var comp = boxi.AddComponent<Box>();
        
        comp.color = color;
        comp.weight = weight;
        comp.isFull = isFull;
        comp.contents = contents;
        box.tag = "Box"; // Assign the "Box" tag to the instantiated box object
    }

    private void Start()
    {
    }

    public void Update()
    {
    }
}
