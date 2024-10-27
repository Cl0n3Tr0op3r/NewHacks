using UnityEngine;
using System;
using System.Collections.Generic;

public class Isometric2DMovement : MonoBehaviour
{
    [SerializeField] private int x_pos;
    [SerializeField] private int y_pos;
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite[] spriteArray;
    TilemapMapGenerator map;

    [SerializeField] public bool isTimePaused = false;
    public Queue<int> player_inputs = new Queue<int>();

    public static LinkedList<GameObject> players = new LinkedList<GameObject>();


    void Start()
    {
        transform.position=new Vector3(0f,0f,0f);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        map = GameObject.Find("Grid").GetComponent<TilemapMapGenerator>();
        // players.AddLast(this);
    }

    void Update()
    {  
        if (!isTimePaused)
        {
            if (player_inputs.Count != 0) {
                for (int i = 0; i < player_inputs.Count; i++)
                {
                    move(player_inputs.Dequeue());
                }
            }
            else
            {
                if (Input.GetKeyDown("w")) move(1);
                if (Input.GetKeyDown("a")) move(2);
                if (Input.GetKeyDown("s")) move(3);
                if (Input.GetKeyDown("d")) move(4);
            }
        }
        else
        {
                Debug.Log(player_inputs.Count);
            if (Input.GetKeyDown("w")) player_inputs.Enqueue(1);
            if (Input.GetKeyDown("a")) player_inputs.Enqueue(2);
            if (Input.GetKeyDown("s")) player_inputs.Enqueue(3);
            if (Input.GetKeyDown("d")) player_inputs.Enqueue(4);
        }
    }

    void move(int dir) {
        // dir    1 2 3 4
        // key    w a s d
        
        Vector3 pos = transform.position;
        
        if (dir == 1){
            if((map.end_y)>=y_pos){
                y_pos+=1;
            }
            spriteRenderer.sprite = spriteArray[1];
        }
        else if (dir == 3){
            if(map.start_y+2<y_pos){
                y_pos-=1;
            }
             spriteRenderer.sprite = spriteArray[3];
        }
        else if (dir == 2){
            if(map.start_x<=x_pos){
                x_pos-=1;
            }
             spriteRenderer.sprite = spriteArray[2];
        }
        else if (dir == 4){
            if((-2+map.end_x)>x_pos){
                x_pos+=1;
            }
            
            spriteRenderer.sprite = spriteArray[0];
            
        }
        
        transform.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f);

    }
}
