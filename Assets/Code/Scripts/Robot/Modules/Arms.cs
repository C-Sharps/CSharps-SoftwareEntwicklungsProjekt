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

    // Repairs an object in a certain direction from the robot
    internal IEnumerator _Repair(Direction direction)
    {
        Debug.Log("In _Repair");

        // Makes a box cast next to the robot to get the object to repair
        RaycastHit[] hits = Physics.BoxCastAll(
            gameObject.transform.position + DirectionExtension.DirectionToVector3(direction) * 0.5f,
            new Vector3(0.25f, 0.25f, 0.25f),
            Vector3.down
            );

        foreach (RaycastHit hit in hits)
        {
            Debug.Log(hit.transform.name);
        }

        yield return null;
    }
}