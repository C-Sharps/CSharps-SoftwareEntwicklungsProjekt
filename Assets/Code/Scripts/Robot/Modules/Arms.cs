using System.Collections;
using System.Collections.Generic;
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

    // Pick up object infront of Robot.
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

    // Place an object infront of the Robot. 
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
}