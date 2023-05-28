using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    private Body body;
    [SerializeField]
    private Legs legs;
    [SerializeField]
    private Arms arms;
    [SerializeField]
    private Head head;

    // The list of task the Robot is about to do.
    [SerializeField]
    private Queue<IEnumerator> _tasks = new Queue<IEnumerator>();

    public Robot(){
        Debug.Log(this.name + ": In constructor");
        body = new Body();
        legs = new Legs();
        arms = new Arms();
        head = new Head();
    }

    public void PickUp()
    {
        Transform GrabPosition = transform.Find("GrabPosition");
        _tasks.Enqueue(arms._Pickup(GrabPosition.gameObject));
    }

    public void PutDown() {

        _tasks.Enqueue(arms._PutDown(gameObject));
    }

    public void Move(Direction direction)
    {
        legs._Move(direction);
    }

    void Start()
    {
        // Give the robot commands here
        PickUp();
        Move(Direction.North);
        Move(Direction.East);
        PutDown();
        Move(Direction.North);
        Move(Direction.North);
        Move(Direction.North);

    }

    public void Update()
    {
        if (_tasks.Count > 0 && _tasks.Peek() != null)
        {
            StartCoroutine(_tasks.Dequeue());
        }
        else if (_tasks.Count <= 0)
        {
            Debug.Log(this.name + ": Queue _tasks is empty, all tasks finished.");
        }
    }
}