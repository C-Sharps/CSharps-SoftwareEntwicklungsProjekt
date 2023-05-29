using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    [SerializeField]
    // The Array of items the Robot can carry.
    private GameObject _IsHolding;

    [SerializeField]
    private GameObject[] _InteractableObjects;

    // Pick up object infront of Robot.
    internal IEnumerator _Pickup(GameObject Parent){
        foreach( GameObject Object in _InteractableObjects){
            float distance = Vector3.Distance(Parent.transform.position,Object.transform.position);
           
            if(distance<= 1){
                Object.transform.parent = Parent.transform;
                Object.transform.position = Parent.transform.position;
                _IsHolding = Object;
                break;
            }

        }
        yield return null;  
    }

    // Place an object infront of the Robot. 
    internal IEnumerator _PutDown(GameObject Robot) {
 
        if(_IsHolding!=null) {
            
            Vector3 P = transform.position;

            //TODO : Abhängig von Roboter richtung machen
            P.x = Mathf.Floor((P.x + 1f)); 
           
            _IsHolding.transform.parent = null;
            _IsHolding.transform.position = P;

        }
        yield return null;
    }
}
