using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using UnityEngine.Tilemaps;

public class GridGenerator : ScriptableObject
{
    public string gridName;
    private GameObject gridObject;
    private Grid grid;
    public Sprite tileSprite;
    private Tilemap tilemap;
    public Vector3 origin;
    public GridOrientation orientation;
    public Vector2Int gridSize;
    public float cellSizeX = 1f;
    public float cellSizeY = 1f;
    public bool useLabels;
    private Canvas canvas;
    public TMP_Text gridLabel;
    public delegate void Function();
    public Function generateGrid;

    public void GenerateGrid()
    {
        if (gridObject != null)
        {
            Object.Destroy(gridObject);
        }

        if (gridName.NullIfEmpty().IsUnityNull())
        {
            gridName = "Grid";
        }

        gridObject = new GameObject(gridName);
        Quaternion rotation = GetRotationForOrientation(orientation);
        gridObject.transform.rotation = rotation;
        grid = gridObject.AddComponent<Grid>();
        grid.cellSize = new Vector3(cellSizeX, 1f, cellSizeY);
        gridObject.transform.position = origin;

        if (useLabels)
        {
            canvas = grid.AddComponent<Canvas>();
            SetGridText();
        }

        if (tileSprite != null)
        {
            FillGridWithTiles();
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

    public void SetGridText()
    {
        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                TMP_Text newlabel = Object.Instantiate(gridLabel);
                newlabel.rectTransform.SetParent(canvas.transform, false);
                newlabel.rectTransform.anchoredPosition = new Vector2(x + 0.5f, y + 0.5f);
                newlabel.text = x + ", " + y;
            }
        }
    }

    private void FillGridWithTiles()
    {
        tilemap = gridObject.AddComponent<Tilemap>();
        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = tileSprite;

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; y < gridSize.x; x++)
            {
                tilemap.SetTile(new Vector3Int(x, y), tile);
            }
        }
    }
}
