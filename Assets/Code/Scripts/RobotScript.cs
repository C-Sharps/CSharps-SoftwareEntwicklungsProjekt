using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class RobotScript: MonoBehaviour
{

    [SerializeField]
    //Movement Speed of the Robot.
    private float Speed = 20f;

    private bool isRunning = false;
    private Queue<IEnumerator> Tasks = new Queue<IEnumerator>();

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

    public void Move(float x, float y){Tasks.Enqueue(_Move(x,y));}
    public void Move(int x, int y){Tasks.Enqueue(_Move((float)x,(float)y));}

    public void Start() {
    
        for (int i = 0; i < 2; i++) {
            Move(1,0);
        }

        Move(1f,2f);
        Move(-1f,-2f);
    }

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