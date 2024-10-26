using UnityEngine;
using System;

public class Isometric2DMovement : MonoBehaviour
{
    [SerializeField] private int x_pos;
    [SerializeField] private int y_pos;
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite[] spriteArray;
    TilemapMapGenerator map;

    void Start()
    {
        transform.position=new Vector3(0f,0f,0f);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        map = GameObject.Find("Grid").GetComponent<TilemapMapGenerator>();
    }

    void Update()
    {  


        Vector3 pos = transform.position;
        
        if (Input.GetKeyDown("w")){
            if((map.end_y)>=y_pos){
                y_pos+=1;
            }
            spriteRenderer.sprite = spriteArray[1];
        }
        else if (Input.GetKeyDown("s")){
            if(map.start_y+2<y_pos){
                y_pos-=1;
            }
             spriteRenderer.sprite = spriteArray[3];
        }
        else if (Input.GetKeyDown("a")){
            if(map.start_x<=x_pos){
                x_pos-=1;
            }
             spriteRenderer.sprite = spriteArray[2];
        }
        else if (Input.GetKeyDown("d")){
            if((-2+map.end_x)>x_pos){
                x_pos+=1;
            }
            
            spriteRenderer.sprite = spriteArray[0];
            
        }
       
        

        
        transform.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f);

    }
}
