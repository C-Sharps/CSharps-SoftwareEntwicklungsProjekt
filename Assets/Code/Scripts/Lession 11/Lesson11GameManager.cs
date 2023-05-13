using UnityEngine;
using UnityEngine.Tilemaps;

public class Lesson11GameManager : AbstractGameManager
{
    [SerializeField]
    private Vector2Int gridSize = new Vector2Int(12, 6);
    [SerializeReference]
    TileBase intactTile;

    private void Start()
    {
        PlayLession();
    }

    // Assert that all tiles are repaired (equaling the intactTile field).
    public sealed override bool AssertLessionTargetComplete()
    {
        Tilemap tilemap = GameObject.Find("Grid").GetComponentInChildren<Tilemap>();
        Debug.Log(intactTile);

        // It's also possible to use tilemap.GetTilesBlock(Bounds) to iterate through a TileBase array.

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                Debug.Log( "(" + x + ", " + y + ")" );
                TileBase tile = tilemap.GetTile(new Vector3Int(x, y));
                if ( !(tile.GetType() == intactTile.GetType()) ) {
                    Debug.Log("Tile on (" + x + ", " + y + ") not an intact tile!");
                    return false;
                }
            }
        }
        return true;
    }
}
