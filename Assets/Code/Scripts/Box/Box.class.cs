using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Code.Scripts;
using Code.Scripts.System.SceneManager;
using UnityEngine;
using RoslynCSharp;
using TMPro;


public class Box : MonoBehaviour
{
    // Attribute for the color of the box
    public Color color;

    // Attribute for the weight of the box
    public float weight;

    // Attribute for the size of the box
    public int scale;

    // Attribute to track if the box is full
    public bool isFull;

    // Attribute for the contents of the box
    public string contents;

    private LessonController _controller;

    // Constructor to initialize the attributes of the box
    public Box(Color color, float weight, bool isFull, string contents, int scale)
    {
        this.color = color;
        this.weight = weight;
        this.isFull = isFull;
        this.contents = contents;
        this.scale = scale;

        _controller = GameObject.FindObjectOfType<LessonController>();

        if(this.scale < 11) {
            CreateBox(this.scale);
        } else {
            _controller.DisplayError("              FUCKROBOTS");
        }        
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

    private void CreateBox(int scale)
    {
        var box = Instantiate(Resources.Load<GameObject>("Prefabs/Box"), new Vector3(5.75f, 8f, 0f),
            Quaternion.identity);
        box.transform.localScale = new Vector3(scale, scale, scale);
        box.GetComponentsInChildren<MeshRenderer>()[0].material.color = color;
        box.transform.Rotate(0f, 180f, 0f);

        var comp = box.AddComponent<Box>();
        
        comp.color = color;
        comp.weight = weight;
        comp.isFull = isFull;
        comp.contents = contents;
        box.tag = "Box"; // Assign the "Box" tag to the instantiated box object
    }
     
    private void CreateBox()
    {
        var box = Instantiate(Resources.Load<GameObject>("Prefabs/Box"), new Vector3(5.75f, 8f, 0f),
            Quaternion.identity);
        box.GetComponentsInChildren<MeshRenderer>()[0].material.color = color;
        box.transform.Rotate(0f, 180f, 0f);

        var comp = box.AddComponent<Box>();
        
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
