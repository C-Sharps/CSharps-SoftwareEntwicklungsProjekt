using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLegacy : RobotScriptLegacy
{
    
    public Body Body;
    public Legs Leg;
    public Arms LeftArm;
    public Arms RightArm;
    public Head Head;

    public RobotLegacy(){
        Body = new Body();
        Leg = new Legs();
        LeftArm = new Arms();
        RightArm = new Arms();
        Head = new Head();

        Debug.Log("Test");
    }

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
    new void Update() {
        base.Update(); // Required for the robot to execute commands, do not remove

    }
}
