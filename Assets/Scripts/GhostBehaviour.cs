using UnityEngine;
using System;
using System.Collections.Generic;
using Cinemachine;

public class GhostBehaviour : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam; 
    public int x_pos;
    public int y_pos;
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite[] spriteArray;
    TilemapMapGenerator map;
    public bool dead;
    public static bool gameOver;
    public bool yourTurn;
    public (int, int) startPos;
    public int remTurns;

    public Queue<int> player_inputs = new Queue<int>();


    public static LinkedList<GhostBehaviour> list_of_players = new LinkedList<GhostBehaviour>();


    void Start()
    {
        yourTurn=true;
        
        //

        startPos = (x_pos, y_pos);
        remTurns=6; 

        //

        transform.position=new Vector3(0f,0f,0f);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        map = GameObject.Find("Grid").GetComponent<TilemapMapGenerator>();
        list_of_players.AddLast(this);

    }

    void Update()
    {  
        bool isTimePaused = GameObject.Find("player_characters").GetComponent<Isometric2DMovement>().isTimePaused;
        if (isTimePaused)
        {
            Debug.Log(player_inputs.Count);
    
            

            if (Input.GetKeyDown("w")) 
            {
                move(1);
                
            }
            else if (Input.GetKeyDown("a")) 
            {
                move(2);
                
            }
            else if (Input.GetKeyDown("s")) 
            {
                move(3);
;
            }
            else if (Input.GetKeyDown("d")) 
            {
                move(4);
                
            }
        }
    }

    void move(int dir)
    {
        move(dir, this.transform, this.spriteRenderer);
    }
    void move(int dir, Transform target, SpriteRenderer spriteRenderer)
    {
        // dir    1 2 3 4
        // key    w a s d
        // dir    10 11 12 13
        // attack 
        
        
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

        else if (dir == 11){
            Debug.Log("");
        }
        else if (dir == 12){
            Debug.Log("");
        }
        else if (dir == 13){
           Debug.Log("");
        }
        else if (dir == 14){
            Debug.Log("");
        }
        
        target.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f);

    }
}
