using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Burst.Intrinsics;

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

    private Animator Animator;
    // The list of task the Robot is about to do.
    [SerializeField]
    private Queue<IEnumerator> _tasks = new Queue<IEnumerator>();


    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public Robot(Color32 color) {
        var Robot = Instantiate(Resources.Load<GameObject>("Prefabs/Robot"), new Vector3(5.75f, 8f, 0f),
            Quaternion.identity);
        Robot.GetComponentsInChildren<MeshRenderer>()[5].material.color = color;
        Robot.transform.Rotate(0f, 180f, 0f);

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
    
    public Vector2 GetPosition()
    {
        return new Vector2(transform.position.x, transform.position.z);
    }

    public void Move(Direction direction)
    {
        _tasks.Enqueue(legs._Move(direction));
    }

    public void Dance()
    {
        _tasks.Enqueue(DoDance());
    }

    public IEnumerator DoDance()
    {
        Animator.SetTrigger("Dance");
        yield return null;
    }

    public void Update()
    {
        Animator.SetBool("isRunning", _tasks.Count > 0);
        Animator.speed = legs._Speed;
        
        if (_tasks.Count > 0 && _tasks.Peek() != null && !legs._isRunning)
        {
            StartCoroutine(_tasks.Dequeue());
        }
        else if (_tasks.Count <= 0)
        {
            Debug.Log(this.name + ": Queue _tasks is empty, all tasks finished.");
        }
    }
}
