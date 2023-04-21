using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public TMP_Text text;
    public GameObject capsule;

    public void ChangeColor()
    {
        text.text = "Arschnase";
        capsule.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
