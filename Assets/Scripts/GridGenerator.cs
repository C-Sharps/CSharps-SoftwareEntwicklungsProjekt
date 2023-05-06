using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject gridObject;
    [SerializeField]
    private Grid grid;
    public Vector3 origin;
    public GridOrientation orientation;
    public Vector2Int gridSize;
    public float cellSizeX = 1f;
    public float cellSizeY = 1f;
    public bool useLabels;
    public TMP_Text gridLabel;
    public delegate void Function();
    public Function generateGrid;

    private void OnValidate()
    {
       GenerateGrid();
    }

    public void GenerateGrid()
    {
        if (gridObject == null)
        {
            gridObject = new GameObject("Grid");
            Quaternion rotation = GetRotationForOrientation(orientation);
            gridObject.transform.rotation = rotation;
            //Instantiate(gridObject, origin, rotation);
        }

        grid = gridObject.AddComponent<Grid>();
        grid.cellSize = new Vector3(cellSizeX, 1f, cellSizeY);
        gridObject.transform.position = origin;

        if (useLabels)
        {
            Canvas canvas = grid.AddComponent<Canvas>();
            GridText.setGridText(grid, canvas, gridLabel, gridSize.x, gridSize.y);
        }
    }

    public enum GridOrientation { XZ, XY, YZ };

    private Quaternion GetRotationForOrientation(GridOrientation orientation)
    {
        switch (orientation)
        {
            case GridOrientation.XZ: return Quaternion.Euler(90f, 0f, 0f);
            case GridOrientation.XY: return Quaternion.identity;
            case GridOrientation.YZ: return Quaternion.Euler(0f, -90f, 0);
            default: return Quaternion.identity;
        }
    }
}
