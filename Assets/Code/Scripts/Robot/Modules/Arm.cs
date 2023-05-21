using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField]
    // The list of task the Robot is about to do.
    private Queue<IEnumerator> _Tasks = new Queue<IEnumerator>();

    [SerializeField]
    // The Array of items the Robot can carry.
    private GameObject _IsHolding;

    [SerializeField]
    private GameObject[] _InteractableObjects;

    // Pick up object infront of Robot.
    IEnumerator _Pickup(GameObject Parent){
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
    IEnumerator _PutDown(GameObject Robot) {
 
        if(_IsHolding!=null) {
            
            Vector3 P = transform.position;

            //TODO : Abhängig von Roboter richtung machen
            P.x = Mathf.Floor((P.x + 1f)); 
           
            _IsHolding.transform.parent = null;
            _IsHolding.transform.position = P;

        }
        yield return null;
    }

    public void Pickup(){
        Transform GrabPosition = transform.Find("GrabPosition");
        _Tasks.Enqueue(_Pickup(GrabPosition.gameObject));
    }

    public void PutDown(){
        _Tasks.Enqueue(_PutDown(gameObject));
    }

    public void Update() {
        if(_Tasks.Count>0 && _Tasks.Peek() != null){
            StartCoroutine(_Tasks.Dequeue());
        }
        else if(_Tasks.Count <= 0)
        {
            // Debug.Log("Done!");
        }
    }
}
