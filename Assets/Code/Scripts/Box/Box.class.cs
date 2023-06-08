using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Burst.Intrinsics;

public class Box : MonoBehaviour
{
    // Attribute for the color of the box
    public Color32 Color;

    // Attribute for the weight of the box
    public float Weight;

    // Attribute to track if the box is full
    public bool IsFull;

    // Attribute for the contents of the box
    public string Contents;

    private void Start()
    {
    }

    // Constructor to initialize the attributes of the box
    public Box(Color32 color, float weight, bool isFull, string contents) 
    {
        var Boxi = Instantiate(Resources.Load<GameObject>("Prefabs/Box"), new Vector3(5.75f, 8f, 0f),
            Quaternion.identity);
        Boxi.GetComponentsInChildren<MeshRenderer>()[0].material.color = color;
        Boxi.transform.Rotate(0f, 180f, 0f);

        var comp = Boxi.AddComponent<Box>();
        
        comp.Color = color;
        comp.Weight = weight;
        comp.IsFull = isFull;
        comp.Contents = contents;

        
    }

    public void Update()
    {
    }
}
