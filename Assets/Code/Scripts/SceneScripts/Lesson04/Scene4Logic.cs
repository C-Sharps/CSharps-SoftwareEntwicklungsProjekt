using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using Code.Scripts.System.SceneManager;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using RoslynCSharp;
using System.Linq;
using static Checking;

public class Scene4Logic : MonoBehaviour
{
    GameObject[] boxes;

    private LessonController _controller;
    private Checking _checking;
    private GameObject _boxPrefab;

    private int i = 0;

    private GameObject _red;
    private GameObject _blue;
    private GameObject _green;
    private GameObject _yellow;
    private GameObject _black;
    
    public void Awake()
    {
        _controller = FindObjectOfType<LessonController>();
        
        _checking = FindObjectOfType<Checking>();

        _boxPrefab = Resources.Load<GameObject>("Prefabs/Box");
    }

    public void Start()
    {
        _red = Instantiate(_boxPrefab, new Vector3(5.75f, 3f, 0f),
            Quaternion.identity);
        _red.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        _red.GetComponentsInChildren<MeshRenderer>()[0].material.color = Color.red;
        _red.transform.Rotate(0f, 180f, 0f);

        _blue = Instantiate(_boxPrefab, new Vector3(5.75f, 6f, 0f),
            Quaternion.identity);
        _blue.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        _blue.GetComponentsInChildren<MeshRenderer>()[0].material.color = Color.blue;
        _blue.transform.Rotate(0f, 180f, 0f);

        _green = Instantiate(_boxPrefab, new Vector3(5.75f, 8f, 0f),
            Quaternion.identity);
        _green.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
        _green.GetComponentsInChildren<MeshRenderer>()[0].material.color = Color.green;
        _green.transform.Rotate(0f, 180f, 0f);

        _yellow = Instantiate(_boxPrefab, new Vector3(5.75f, 10f, 0f),
            Quaternion.identity);
        _yellow.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
        _yellow.GetComponentsInChildren<MeshRenderer>()[0].material.color = Color.yellow;
        _yellow.transform.Rotate(0f, 180f, 0f);

        _black = Instantiate(_boxPrefab, new Vector3(5.75f, 12f, 0f),
            Quaternion.identity);
        _black.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        _black.GetComponentsInChildren<MeshRenderer>()[0].material.color = Color.black;
        _black.transform.Rotate(0f, 180f, 0f);
    }

    public void Update()
    {
        if (GetObjArray(i) && i < 7)
        {
            _controller.CompleteObjective(i);
            i++;
        }
    }
}
