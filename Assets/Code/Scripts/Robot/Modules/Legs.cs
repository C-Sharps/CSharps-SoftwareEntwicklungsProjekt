using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    [SerializeField]
    // The list of task the Robot is about to do.
    private Queue<IEnumerator> _Tasks = new Queue<IEnumerator>();

    [SerializeField]
    // Movement Speed of the Robot.
    private float _Speed = 1f;

    [SerializeField]
    // Is the Robot running.
    private bool _isRunning = false;
    
    [SerializeField]
    // The direction the Robot facing;
    private Direction _dir;

    internal IEnumerator _Move(Direction direction)
    {
        return _Move(DirectionExtension.DirectionToVector2(direction));
    }

    internal IEnumerator _Move(Vector2 direction)
    {
        return _Move(direction.x, direction.y);
    }
    internal IEnumerator _Move(float x, float y)
    {
        
        _isRunning = true;
        if(x != 0 || y != 0) {
        
        float dist = Mathf.Sqrt(x*x+y*y);
        float time = dist/_Speed;

        Vector3 Start = transform.position;
        Vector3 End = Start + new Vector3(x, 0 ,y);

        float t = 0;
        while(t < time)
        {
            transform.position = Vector3.Lerp(Start,End,t/time);
            t = t + Time.deltaTime;
            yield return null;
        }

        // Prevents rounding errors and imprecision
        transform.position = End;
        }
        _isRunning = false;
    }

    public void Update() {
        if(_Tasks.Count>0 && _Tasks.Peek() != null && !_isRunning){
            StartCoroutine(_Tasks.Dequeue());
        }
        else if(!_isRunning && _Tasks.Count <= 0)
        {
            // Debug.Log("Done!");
        }
    }
}
