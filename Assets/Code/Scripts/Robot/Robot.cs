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
        Move(Direction.North);
        Move(Direction.North);
        Move(Direction.North);
        Pickup();
        Move(Direction.East);
        PutDown();
        Move(Direction.East);
        Move(Direction.South);

    }

    // Update is called once per frame
    // Ensure any Commads given in Update Are only given once to avoid loops
    
    void Update() {
        base.Update(); // Required for the robot to execute commands, do not remove

    


    }
}
