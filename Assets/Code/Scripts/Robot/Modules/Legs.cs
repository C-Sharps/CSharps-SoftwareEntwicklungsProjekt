using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    [SerializeField]
    // Movement Speed of the Robot.
    private float _Speed = 1f;

    [SerializeField]
    // Is the Robot running.
    private bool _isRunning = false;

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
            transform.position = Vector3.Lerp(Start, End, t/time);
            t += Time.deltaTime;
            yield return null;
        }

        // Prevents rounding errors and imprecision
        transform.position = End;
        }
        _isRunning = false;
    }
}
