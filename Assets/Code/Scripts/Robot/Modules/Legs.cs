/**
 * Author: Stefan Pietzner
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    [SerializeField]
    // Movement Speed of the Robot.
    public float _Speed = 1f;

    [SerializeField]
    // Is the Robot running.
    public bool _isRunning = false;
    
    [SerializeField]
    // The direction the Robot facing;
    private Direction _dir;

    internal IEnumerator _Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
            case Direction.South:
            case Direction.East:
            case Direction.West:
                return _Move(DirectionExtension.DirectionToVector2(direction));
            default: 
                return MoveRelativeToOrientation(direction);
        }
    }

    private IEnumerator _Move(Vector2 direction)
    {
        return _Move(direction.x, direction.y);
    }

    public IEnumerator _Move(float x, float y)
    {
        _isRunning = true;
        if(x != 0 || y != 0) {
        
            float dist = Mathf.Sqrt(x*x+y*y);
            float time = dist/_Speed;

            Vector3 Start = transform.position;
            Vector3 End = Start + new Vector3(x, 0 ,y);
            transform.LookAt(End);

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

    private IEnumerator MoveRelativeToOrientation(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
                return _Move(Vector3ToVector2(gameObject.transform.forward));
            case Direction.Backward:
                return _Move(Vector3ToVector2(-gameObject.transform.forward));
            case Direction.Right:
                return _Move(Vector3ToVector2(gameObject.transform.right));
            case Direction.Left:
                return _Move(Vector3ToVector2(-gameObject.transform.right));
            default:
                throw new ArgumentException("Not a valid direction!");
        }
    }

    private Vector2 Vector3ToVector2(Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.z);
    }
}
