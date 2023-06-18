/**
 * Author: Stefan Pietzner
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using System;
using UnityEngine;


/// <summary>Enum for different directions in the game's world space.</summary> 
public enum Direction
{

    North, South, East, West, Forward, Backward, Left, Right
}

/// <summary>
///  Static class for different for handling <see cref="Direction">Direction</see> enums.
/// </summary>
public static class DirectionExtension
{

    public static Vector2 DirectionToVector2(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return new Vector2(0, 1);

            case Direction.South:
                return new Vector2(0, -1);

            case Direction.East:
                return new Vector2(1, 0);

            case Direction.West:
                return new Vector2(-1, 0);

            case Direction.Forward:
            case Direction.Backward:
            case Direction.Left:
            case Direction.Right:
                throw new ArgumentException("Cannot call DirectionToVector2(Direction) with relative directions!");

            default: throw new ArgumentException(direction + " is not a valid value for enum \'Direction!\'");
        }
    }

    public static Vector3 DirectionToVector3(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return new Vector3(0, 0, 1);

            case Direction.South:
                return new Vector3(0, 0, -1);

            case Direction.East:
                return new Vector3(1, 0, 0);

            case Direction.West:
                return new Vector3(-1, 0, 0);

            case Direction.Forward:
            case Direction.Backward:
            case Direction.Left:
            case Direction.Right:
                return RelativeDirectionToVector3(direction);

            default: throw new ArgumentException(direction + " is not a valid value for enum \'Direction!\'");
        }
    }

    private static Vector3 RelativeDirectionToVector3(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return new Vector3(0, 0, 1);

            case Direction.South:
                return new Vector3(0, 0, -1);

            case Direction.East:
                return new Vector3(1, 0, 0);

            case Direction.West:
                return new Vector3(-1, 0, 0);

            default: throw new ArgumentException(direction + " is not a valid value for enum \'Direction!\'");
        }
    }
}