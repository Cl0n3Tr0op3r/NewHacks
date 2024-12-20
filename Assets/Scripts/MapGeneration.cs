using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapMapGenerator : MonoBehaviour
{
    public Tilemap tilemap;  
    public TileBase tile;   
    public int start_x = -3;   
    public int end_x = 3;
    public int start_y = -7;
    public int end_y = 7;


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
              
                tilemap.SetTile(new Vector3Int(y,x, 0), tile);
            }
        }
    }
}