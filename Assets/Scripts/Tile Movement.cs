using UnityEngine;
using System;
using System.Collections.Generic;
using Cinemachine;

public class Isometric2DMovement : MonoBehaviour
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
    [SerializeField] private GameObject ghost;

    [SerializeField] public bool isTimePaused = false;
    public Queue<int> player_inputs = new Queue<int>();
    [SerializeField] public GameObject pausedMoveIndicator;


    public static LinkedList<Isometric2DMovement> list_of_players = new LinkedList<Isometric2DMovement>();


    void Start()
    {
        yourTurn=true;
        
        //

        startPos = (x_pos, y_pos);
        isTimePaused = true;
        remTurns=6; 

        //

        transform.position=new Vector3(0f,0f,0f);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        map = GameObject.Find("Grid").GetComponent<TilemapMapGenerator>();
        list_of_players.AddLast(this);

    }

    void Update()
    {  
        if (!isTimePaused)
        {
            vcam.Follow = GameObject.Find("player_characters").transform;
            if (player_inputs.Count != 0) {
                while (player_inputs.Count!=0){
                    move(player_inputs.Dequeue());
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.Escape)){
                    remTurns=6;
                    (x_pos, y_pos) = startPos;
                } 

            }
        }
        else
        {
            vcam.Follow = GameObject.Find("player_characters_ghost").transform;
            if (Input.GetKeyDown("w")) 
            {
                move(1, pausedMoveIndicator.transform, pausedMoveIndicator.GetComponent<SpriteRenderer>());
                // pausedMoveIndicator.transform.position = new Vector3(1,1,0);
                print(pausedMoveIndicator.transform.position);
                player_inputs.Enqueue(1);
            }
            if (Input.GetKeyDown("a")) 
            {
                move(2, pausedMoveIndicator.transform, pausedMoveIndicator.GetComponent<SpriteRenderer>());
                player_inputs.Enqueue(2);
            }
            if (Input.GetKeyDown("s")) 
            {
                move(3, pausedMoveIndicator.transform, pausedMoveIndicator.GetComponent<SpriteRenderer>());
                player_inputs.Enqueue(3);
            }
            if (Input.GetKeyDown("d")) 
            {
                move(4, pausedMoveIndicator.transform, pausedMoveIndicator.GetComponent<SpriteRenderer>());
                player_inputs.Enqueue(4);
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
        
        Vector3 pos = target.position;
        
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
        
        target.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f);

    }
}
