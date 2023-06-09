/**
 * Author: Stefan Pietzner
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using UnityEngine;

public class BrokenSolarPanel : SolarPanel, IRepairable
{
    new bool _isIntact = false;

    [SerializeField]
    private GameObject intactSolarPanel;

    public void Repair()
    {
        var repairedPanel = Instantiate(intactSolarPanel, transform.position, transform.rotation, transform.parent);
        repairedPanel.name = 
            "Solar Panel " + gameObject.name.Substring(gameObject.name.IndexOf('('));
        repairedPanel.transform.SetSiblingIndex(gameObject.transform.GetSiblingIndex());
        Destroy(gameObject);
    }
}
