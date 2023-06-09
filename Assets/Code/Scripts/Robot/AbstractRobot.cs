using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRobot : MonoBehaviour
{
    // TODO: Commented out for testing purposes
    /*
    [SerializeField]
    protected Body body;
    [SerializeField]
    protected Legs legs;
    [SerializeField]
    protected Arms arms;
    [SerializeField]
    protected Head head;
    [SerializeField]
    protected Color color;

    protected GameObject robotPrefab;

    // The list of task the Robot is about to do.
    [SerializeField]
    private Queue<IEnumerator> _tasks = new Queue<IEnumerator>();

    void Awake()
    {
        robotPrefab = Resources.Load<GameObject>("Prefabs/Robot");
        SetModules();
    }

    public void PickUp()
    {
        Transform GrabPosition = transform.Find("GrabPosition");
        _tasks.Enqueue(arms._Pickup(GrabPosition.gameObject));
    }

    public void PutDown()
    {

        _tasks.Enqueue(arms._PutDown(gameObject));
    }

    public void Move(Direction direction)
    {
        legs._Move(direction);
    }

    protected GameObject InstantiateRobot()
    {
        GameObject newRobot = Instantiate(
            Resources.Load<GameObject>("Prefabs/Robot"));
        return newRobot;
    }

    public void Update()
    {
        if (_tasks.Count > 0 && _tasks.Peek() != null)
        {
            StartCoroutine(_tasks.Dequeue());
        }
        else if (_tasks.Count <= 0)
        {
        }
    }
   

    protected void SetModules()
    {
        body = gameObject.AddComponent<Body>();
        legs = gameObject.AddComponent<Legs>();
        arms = gameObject.AddComponent<Arms>();
        head = gameObject.AddComponent<Head>();
    }
     */
}
