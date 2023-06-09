using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScriptLegacy: MonoBehaviour
{

    [SerializeField]
    //Movement Speed of the Robot.
    private float Speed = 1f;

    private bool isRunning = false;
    private Queue<IEnumerator> Tasks = new Queue<IEnumerator>();


    [SerializeField]
    private GameObject[] interactableObjects;

    //[SerializeField]
    private GameObject isHolding;
    //Moves Robot by Lerping between start and end position

    IEnumerator _Move(Vector2 direction)
    {
        return _Move(direction.x, direction.y); 
    }

    IEnumerator _Move(float x, float y)
    {
        
        isRunning = true;
        if(x != 0 || y != 0) {
        
        float dist = Mathf.Sqrt(x*x+y*y);
        float time = dist/Speed;

        Vector3 Start = transform.position;
        Vector3 End = Start + new Vector3(x, 0 ,y);

        float t = 0;
        while(t < time)
        {
            transform.position = Vector3.Lerp(Start,End,t/time);
            t = t + Time.deltaTime;
            yield return null;
        }

        //Prevents rounding errors and imprecision
        transform.position = End;
        }
        isRunning = false;
    }

    IEnumerator _Pickup(GameObject Parent){
        if(isHolding == null) { 

        foreach( GameObject Object in interactableObjects){
            float distance = Vector3.Distance(Parent.transform.position,Object.transform.position);
           
            if(distance<= 1){
                Object.transform.parent = Parent.transform;
                Object.transform.position = Parent.transform.position;
                isHolding = Object;
                break;
            }

            }
        }

        yield return null;  
    }


    IEnumerator _PutDown(GameObject Robot) {
 
        if(isHolding !=null) {
            
            Vector3 P = transform.position;

            //TODO : Abhängig von Roboter richtung machen
            P.x = Mathf.Floor((P.x + 1f)); 
           
            isHolding.transform.parent = null;
            isHolding.transform.position = P;

        }
        yield return null;
    }

    public void Move(Direction dir){
        Tasks.Enqueue(_Move(DirectionExtension.DirectionToVector2(dir)));
    }

    public void Pickup(){
        Transform GrabPosition = transform.Find("GrabPosition");
        Tasks.Enqueue(_Pickup(GrabPosition.gameObject));
    }

    public void PutDown(){
        Tasks.Enqueue(_PutDown(gameObject));
    }

    //utility functions to allow the player to Check Robot status and add tasks in update accordingly
    public bool isExecutingCommand() {return isRunning;}
    public int remainingCommands() {return Tasks.Count;}


    public void Update() {
        if(Tasks.Count > 0 && Tasks.Peek() != null && !isRunning){
            StartCoroutine(Tasks.Dequeue());
        }
        else if(!isRunning && Tasks.Count <= 0)
        {
            //Debug.Log("Done!");
        }
    }
}