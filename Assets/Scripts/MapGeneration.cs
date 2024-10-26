using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapMapGenerator : MonoBehaviour
{
    public Tilemap tilemap;  
    public TileBase tile;   
    public int width = 10;   
    public int height = 10; 

    public float xSpacing = 0.25f; 
    public float zSpacing = 0.5f;  

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = -10; x < width; x++)
        {
            for (int y = -10; y < height; y++)
            {
              
                tilemap.SetTile(new Vector3Int(x, y,0), tile);
            }
        }
    }
}