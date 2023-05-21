using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    public int x;
    public int y;
    
    public Direction(int x,int y) {
        this.x = x;
        this.y = y;
    }

    public static Direction North = new Direction(1,0);
    public static Direction South = new Direction(-1,0);
    public static Direction East = new Direction(0,-1);
    public static Direction West = new Direction(0,1);
}