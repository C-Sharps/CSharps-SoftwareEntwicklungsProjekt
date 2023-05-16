using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : RobotScript
{
    /*
    Body Body;
    Legs Legs;
    Arm LeftArm;
    Arm RightArm;
    Head Head;
    */


    void Start()
    {
        // Give the robot commands here
        Pickup();
        Move(Direction.North);
        Move(Direction.East);
        PutDown();
        Move(Direction.North);
        Move(Direction.North);
        Move(Direction.North);

    }

    // Update is called once per frame
    // Ensure any Commads given in Update Are only given once to avoid loops
    
    void Update() {
        base.Update(); // Required for the robot to execute commands, do not remove

    }
}
