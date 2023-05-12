using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using UnityEngine.Tilemaps;

public class GridGenerator : ScriptableObject
{
    public string gridName = "Grid";
    private GameObject gridObject;
    [SerializeField]
    private Grid grid;
    public Sprite tileSprite;
    public Vector3 origin;
    public GridOrientation orientation;
    public Vector2Int gridSize = Vector2Int.one;
    public float cellSizeX = 1f;
    public float cellSizeY = 1f;
    public bool shallUseLabels;
    public bool shallCreateTilemap;

    public void GenerateGrid() 
    {
        if (gridSize.x <= 0 || gridSize.y <= 0)
        {
            throw new GridGeneratorException("Cannot set size of grid dimensions (x, y) to zero or negative numbers!");
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

        if (shallUseLabels)
        {
            GameObject canvasObject = new GameObject("Canvas", typeof(Canvas));
            Canvas canvas = canvasObject.GetComponent<Canvas>();
            RectTransform canvasRect = canvas.GetComponent<RectTransform>();

            // Setting the canvas's anchor and pivot to the lower left corner
            canvasRect.pivot= Vector2.zero;
            canvasRect.anchoredPosition = Vector2.zero;

            // Resizing the canvas to match the grid
            canvasRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, gridSize.x * cellSizeX);
            canvasRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, gridSize.y * cellSizeY);

            canvasObject.transform.SetParent(gridObject.transform, false);
            SetGridText(canvas);
        }

        if (shallCreateTilemap)
        {
            CreateTilemap();
        }

        if (tileSprite != null)
        {
            FillGridWithTiles();
        }
    }

    public enum GridOrientation { XZ, XY, YZ };

    private static Quaternion GetRotationForOrientation(GridOrientation orientation)
    {
        switch (orientation)
        {
            case GridOrientation.XZ: return Quaternion.Euler(90f, 0f, 0f);
            case GridOrientation.XY: return Quaternion.identity;
            case GridOrientation.YZ: return Quaternion.Euler(0f, -90f, 0);
            default: return Quaternion.identity;
        }
    }

    public void SetGridText(Canvas canvas)
    {
        // Caution: Assets must be in the "Resources" folder to be able to load them with Resources.Load()!
        TMP_Text gridLabel = Resources.Load<TMP_Text>("GridLabel");
        Vector3 offset = new Vector3(cellSizeX / 2, cellSizeY / 2);

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                TMP_Text newLabel = Instantiate(gridLabel);
                newLabel.gameObject.name = "(" + x + " ," + y + ")";
                newLabel.rectTransform.SetParent(canvas.transform, false);
                newLabel.rectTransform.localPosition = grid.CellToLocal(new Vector3Int(x, y)) + offset;
                newLabel.text = x + ", " + y;
            }
        }
    }

    private void CreateTilemap()
    {
        GameObject tilemapObject = new GameObject("Tilemap", typeof(Tilemap));
        tilemapObject.transform.SetParent(gridObject.transform, false);
        tilemapObject.AddComponent<TilemapRenderer>();
    }

    private void FillGridWithTiles()
    {
        Tile tile = CreateInstance<Tile>();
        tile.sprite = tileSprite;
        Tilemap tilemap = gridObject.GetComponentInChildren<Tilemap>();

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                tilemap.SetTile(new Vector3Int(x, y), tile);
            }
        }
    }

    private class GridGeneratorException : UnityException { 
        public GridGeneratorException(string message) : base(message) { }
    }
}
