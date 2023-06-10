using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour
{
    [SerializeField]
    private bool _isIntact;

    public bool IsIntact()
    {
        return _isIntact;
    }
}
