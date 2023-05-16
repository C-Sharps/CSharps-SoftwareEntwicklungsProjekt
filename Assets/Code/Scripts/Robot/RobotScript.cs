using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class Direction {
    public int x;
    public int y;
    
    public Direction(int x,int y) {
        this.x = x;
        this.y = y;
    }

    public static Direction North = new Direction(1,0);
    public static Direction South = new Direction(-1,0);
    public static Direction East = new Direction(0,-1);
    public static Direction West = new Direction(0,1);

}


public class RobotScript: MonoBehaviour
{





    [SerializeField]
    //Movement Speed of the Robot.
    private float Speed = 1f;

    private bool isRunning = false;
    private Queue<IEnumerator> Tasks = new Queue<IEnumerator>();


    [SerializeField]
    private GameObject[] InteractableObjects;

    //[SerializeField]
    private GameObject IsHolding;
    //Moves Robot by Lerping between start and end position
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
        if(IsHolding == null) { 

        foreach( GameObject Object in InteractableObjects){
            float distance = Vector3.Distance(Parent.transform.position,Object.transform.position);
           
            if(distance<= 1){
                Object.transform.parent = Parent.transform;
                Object.transform.position = Parent.transform.position;
                IsHolding = Object;
                break;
            }

        }
        }

        yield return null;  
    }


    IEnumerator _PutDown(GameObject Robot) {
 
        if(IsHolding!=null) {
            
            Vector3 P = transform.position;

            //TODO : Abhängig von Roboter richtung machen
            P.x = Mathf.Floor((P.x + 1f)); 
           
            IsHolding.transform.parent = null;
            IsHolding.transform.position = P;

        }
        yield return null;
    }


    public void Move(Direction dir){Tasks.Enqueue(_Move(dir.x,dir.y));}

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
        if(Tasks.Count>0 && Tasks.Peek() != null && !isRunning){
            StartCoroutine(Tasks.Dequeue());
        }
        else if(!isRunning && Tasks.Count <= 0)
        {
            //Debug.Log("Done!");
        }
    }
}