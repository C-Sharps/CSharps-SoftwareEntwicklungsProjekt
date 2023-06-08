using System;
using UnityEngine;

public enum Direction
{

    North, South, East, West
}

public static class DirectionExtension  {
    
    public static Vector2 DirectionToVector2(Direction direction)
    {
        switch(direction)
        {
            case Direction.North: 
                return new Vector2(1, 0);

            case Direction.South: 
                return new Vector2(-1, 0);

            case Direction.East: 
                return new Vector2(0, -1);

            case Direction.West: 
                return new Vector2(0, 1);

            default: throw new ArgumentException(direction + " is not a valid value for enum \'Direction!\'");
        }
    }
}