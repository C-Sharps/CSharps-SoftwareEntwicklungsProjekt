using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RobotScript: MonoBehaviour
{
    public void Move()
    {
        InvokeRepeating("_Move", 0, Time.deltaTime);
    }

    public void MoveTo(int x, int y)
    {
        Grid grid = GameObject.Find("Grid").GetComponent<Grid>();
        gameObject.transform.Translate(grid.CellToWorld(new Vector3Int(x, y, 0)));

    }

    private void _Move ()
    {
        gameObject.transform.Translate(Vector3.forward * 0.1f * Time.deltaTime);
    }
}