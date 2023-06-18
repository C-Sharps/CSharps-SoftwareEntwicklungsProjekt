/**
 * Author: Stefan Pietzner
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
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
