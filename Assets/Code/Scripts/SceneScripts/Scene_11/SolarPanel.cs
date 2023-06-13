using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour
{
    [SerializeField]
    protected bool _isIntact = true;

    public bool IsIntact()
    {
        return _isIntact;
    }
}
