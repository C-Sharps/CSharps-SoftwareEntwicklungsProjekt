using System.Collections;
using UnityEngine;

public class Arms : MonoBehaviour
{
    [SerializeField]
    // The item the robot currently carries
    private GameObject _holdObject;

    public GameObject GetHoldObject()
    {
        return _holdObject;
    }

    // Pick up object in front of Robot.
    internal IEnumerator _Pickup(GameObject Parent)
    {
        /* foreach (GameObject Object in _interactableObjects)
        {
            float distance = Vector3.Distance(Parent.transform.position, Object.transform.position);

            if (distance <= 1)
            {
                Object.transform.parent = Parent.transform;
                Object.transform.position = Parent.transform.position;
                _holdObject = Object;
                break;
            }
        

        }*/
        yield return null;
    }

    // Place an object in front of the Robot. 
    internal IEnumerator _PutDown(GameObject Robot)
    {

        if (_holdObject != null)
        {

            Vector3 P = transform.position;

            //TODO : Abhängig von Roboter richtung machen
            P.x = Mathf.Floor((P.x + 1f));

            _holdObject.transform.parent = null;
            _holdObject.transform.position = P;

        }
        yield return null;
    }

    // Repairs an object in the vicinity of the robot
    internal IEnumerator _Repair()
    {
        Debug.Log("In _Repair");

        // Makes a box cast áround the robot, searching for objects to repair in a 0.4f radius
        RaycastHit[] hits = Physics.BoxCastAll(
            gameObject.transform.position,
            new Vector3(0.4f, 0.4f, 0.4f),
            Vector3.down
            );

        foreach (RaycastHit hit in hits)
        {
            IRepairable panelToRepair;
            if (hit.transform.gameObject.TryGetComponent<IRepairable>(out panelToRepair)) {
                Debug.Log(hit.transform.name);
                panelToRepair.Repair();
            }
        }
        yield return null;
    }
}