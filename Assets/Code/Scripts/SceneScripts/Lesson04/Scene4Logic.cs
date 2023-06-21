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

    private GameObject _box1;
    private GameObject _box2;
    
    public void Awake()
    {
        _controller = FindObjectOfType<LessonController>();
        
        _checking = FindObjectOfType<Checking>();

        _boxPrefab = Resources.Load<GameObject>("Prefabs/Box");

        
    }

    public void Start()
    {
        _box1 = Instantiate(_boxPrefab, new Vector3(5.75f, 4f, 0f),
            Quaternion.identity);
        _box1.transform.localScale = new Vector3(2, 2, 2);
        _box1.GetComponentsInChildren<MeshRenderer>()[0].material.color = Color.red;
        _box1.transform.Rotate(0f, 180f, 0f);

        _box2 = Instantiate(_boxPrefab, new Vector3(5.75f, 10f, 0f),
            Quaternion.identity);
        _box2.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
        _box2.GetComponentsInChildren<MeshRenderer>()[0].material.color = Color.yellow;
        _box2.transform.Rotate(0f, 180f, 0f);
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
