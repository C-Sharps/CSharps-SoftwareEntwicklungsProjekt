/**
 * Author: Lukas Fath, Stefan Pietzner
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
    public float _speed = 1f;

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
        Vector2 target = Vector3ToVector2(gameObject.transform.position) + direction; 
        return _Move(new Vector3(target.x, 0, target.y));
    }

    public IEnumerator _MoveTo(int x, int y)
    {
        var grid = FindObjectOfType<Grid>();

        if (grid != null) {
            // An offset of half the size of the grid's cell is needed to center the robot in the middle of a cell
            return _Move(grid.CellToWorld(new Vector3Int(x, y, 0)) + new Vector3(grid.cellSize.x, 0, grid.cellSize.y) * 0.5f);
        }
        else throw new UnityException("No grid component found in this scene!");
    }

    public IEnumerator _Move(Vector3 target)
    {
        // Rotates the robot toward the end
        transform.LookAt(target);

        Vector3 start = transform.position;
        _isRunning = true;

        float dist = Vector3.Distance(start, target);
        float time = dist / _speed;

        float t = 0;
        while (t < time)
        {
            transform.position = Vector3.Lerp(start, target, t / time);
            t += Time.deltaTime;
            yield return null;
        }

        // Prevents rounding errors and imprecision
        //transform.position = end;
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
