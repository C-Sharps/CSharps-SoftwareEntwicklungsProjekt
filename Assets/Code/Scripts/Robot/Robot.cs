/**
 * Author: Stefan Pietzner
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Robot : AbstractRobot
{
    [SerializeField]
    private Body body;
    [SerializeField]
    private Legs legs;
    [SerializeField]
    private Arms arms;
    [SerializeField]
    private Head head;

    private Animator animator;
    // The list of task the Robot is about to do.
    [SerializeField]
    private Queue<IEnumerator> _tasks;

    public event Action OnQueueEmpty;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _tasks = new Queue<IEnumerator>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public Robot(Color color) {
        var robot = Instantiate(Resources.Load<GameObject>("Prefabs/Robot"), new Vector3(5.75f, 8f, 0f),
            Quaternion.identity);
        robot.GetComponentsInChildren<MeshRenderer>()[5].material.color = color;
        robot.transform.Rotate(0f, 180f, 0f);

        body = new Body();
        legs = new Legs();
        arms = new Arms();
        head = new Head();

        robot.tag = "Robot(color)";
    }

    public void PickUp()
    {

    }

    public void PutDown() {

        _tasks.Enqueue(arms._PutDown(gameObject));
    }
    
    public Vector2 GetPosition()
    {
        return new Vector2(transform.position.x, transform.position.z);
    }

    public void Move(int x, int y)
    {
        _tasks.Enqueue(legs._Move((float)x, (float)y));
    }

    public void Move(Direction direction)
    {
        _tasks.Enqueue(legs._Move(direction));
    }

    public void Dance()
    {
        _tasks.Enqueue(_Dance());
    }

    public IEnumerator _Dance()
    {
        animator.SetTrigger("Dance");
        yield return null;
    }

    public void Repair()
    {
        _tasks.Enqueue(arms._Repair());
    }

    public void Update()
    {
        animator.SetBool("isRunning", _tasks.Count > 0);
        animator.speed = legs._Speed;
        
        if (_tasks.Count > 0 && _tasks.Peek() != null && !legs._isRunning)
        {
            StartCoroutine(_tasks.Dequeue());
        }
        else
        {
            OnQueueEmpty?.Invoke();
        }
    }
}
