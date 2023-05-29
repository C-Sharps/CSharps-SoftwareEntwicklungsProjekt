using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : AbstractRobot
{
    public Robot()
    {

    }

    public Robot(Color color)
    {
        GameObject newRobot = InstantiateRobot();
        newRobot.transform.position = new Vector3(5.75f, 8f, 0f);
        newRobot.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        newRobot.GetComponentsInChildren<MeshRenderer>()[5].material.color = color;
    }

    void Start()
    {
        // Give the robot commands here
        Move(Direction.North);
        Move(Direction.East);
        Move(Direction.North);
        Move(Direction.North);
        Move(Direction.North);
    }
}
