using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scene0Logic : MonoBehaviour
{
    [TextArea(3, 10)]
    public string robotSource = "";
    [TextArea(3, 10)]
    public string mainSource = "";
    
    public TMPro.TMP_InputField editorInput;
    public TextMeshProUGUI highlightedText;


    private void Start()
    {
        editorInput.text = robotSource;
        
    }

    public void OnChangeTab(int id)
    {
        editorInput.text = id == 0 ? @"public class Robot : MonoBehaviour, EVA
{
    // Robot Parts
    public Head Head;
    public Body Body;
    public Arm LeftArm;
    public Arm RightArm;
    public Leg LeftLeg;
    public Leg RightLeg;
    private Color

    public Robot(Color32 Color)
    {
        _color = Color; 
    }
}" : mainSource;
        
        highlightedText.text = id == 0 ? @"public class Robot : MonoBehaviour, EVA
{
    // Robot Parts
    public Head Head;
    public Body Body;
    public Arm LeftArm;
    public Arm RightArm;
    public Leg LeftLeg;
    public Leg RightLeg;
    private Color

    public Robot(Color32 Color)
    {
        _color = Color; 
    }
}" : mainSource;

        editorInput.interactable = id != 0;
    }

    public void OnExecute()
    {
        var input = "";
        
    }

}
