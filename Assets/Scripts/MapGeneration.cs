using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapMapGenerator : MonoBehaviour
{
    public Tilemap tilemap;  
    public TileBase tile;   
    public int start_x = -10;   
    public int end_x = 10;
    public int start_y = -10;
    public int end_y = 10;


    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = start_x; x < end_x; x++)
        {
            for (int y = start_y; y < end_y; y++)
            {
              
                tilemap.SetTile(new Vector3Int(x, y,0), tile);
            }
        }
    }
}