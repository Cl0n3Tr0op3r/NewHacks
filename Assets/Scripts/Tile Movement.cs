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


    [SerializeField] public bool isTimePaused = false;
    public Queue<int> player_inputs = new Queue<int>();
    [SerializeField] public GameObject ghost;
    [SerializeField] public GameObject fire_prefab;
    public Queue<GameObject> real_fires = new Queue<GameObject>();
    public int frameDelay = 300;


    public static LinkedList<Isometric2DMovement> list_of_players = new LinkedList<Isometric2DMovement>();


    void Start()
    {

        
        //


        isTimePaused = true;


        //

        transform.position=new Vector3(0f,0f,0f);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        map = GameObject.Find("Grid").GetComponent<TilemapMapGenerator>();
        list_of_players.AddLast(this);

    }

    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.Return)){
            isTimePaused=!isTimePaused;
            ghost.GetComponent<GhostBehaviour>().updateRemainTurns(6);
            foreach (var fire in FireGhost.all_fires){
                    if (fire!=null){
                        Destroy(fire.gameObject, 0f);
                        
                    }
                }
                FireGhost.counter=0;
           
            
           
            
        }
        if (!isTimePaused)
        {
            vcam.Follow = GameObject.Find("player_characters").transform;
            ghost.GetComponent<GhostBehaviour>().x_pos = x_pos;
            ghost.GetComponent<GhostBehaviour>().y_pos = y_pos;
            ghost.transform.position = this.transform.position;
            if (player_inputs.Count != 0) {
                
                if(player_inputs.Count != 0 && Time.frameCount % frameDelay == 0){
                    
                    ghost.SetActive(false);
                    move(player_inputs.Dequeue());
                    
                }                
            }
            if(real_fires.Count!=0 && (Time.frameCount + (frameDelay+10)) % frameDelay == 0){
                Destroy(real_fires.Dequeue().gameObject, 0f);
            }
            /*
            else
            {
                ghost.SetActive(false);
                if (Input.GetKeyDown("w")) move(1);
                if (Input.GetKeyDown("a")) move(2);
                if (Input.GetKeyDown("s")) move(3);
                if (Input.GetKeyDown("d")) move(4); // maybe comment out later
            }
            */

        }
        else
        {
            if(real_fires.Count!=0 && Time.frameCount % frameDelay == 0){
                Destroy(real_fires.Dequeue().gameObject, 0f);
            }
            
            ghost.SetActive(true);
            vcam.Follow = GameObject.Find("player_characters_ghost").transform;
            
            SpriteRenderer pauseMoveIndicatorSprite = ghost.GetComponent<SpriteRenderer>();

            if (Input.GetKeyDown("w")) 
            {
                player_inputs.Enqueue(1);
            }
            else if (Input.GetKeyDown("a")) 
            {
                player_inputs.Enqueue(2);
            }
            else if (Input.GetKeyDown("s")) 
            {
                
                player_inputs.Enqueue(3);
            }
            else if (Input.GetKeyDown("d")) 
            {
                
                player_inputs.Enqueue(4);
            }
            else if (Input.GetKeyDown("up")){
                
                player_inputs.Enqueue(11);
                
            }
            else if (Input.GetKeyDown("left")){
               player_inputs.Enqueue(12);
            }
            else if (Input.GetKeyDown("down")){
               player_inputs.Enqueue(13);
            }
            else if (Input.GetKeyDown("down")){
                player_inputs.Enqueue(14);
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
            GameObject fire = GameObject.Instantiate(fire_prefab) as GameObject;

            Fire fireBehaviour = fire.GetComponent<Fire>(); 
            
            fireBehaviour.x_pos = x_pos;
            fireBehaviour.y_pos = y_pos+1;
            fire.SetActive(true);
            real_fires.Enqueue(fire);
            foreach (Isometric2DMovement player in list_of_players){
                if (player.x_pos == x_pos && player.y_pos == y_pos + 1){
                    player.dead=true;
                    Isometric2DMovement.gameOver = true;
                    // death or attack animation
                }
            }
        }
        else if (dir == 12){

            GameObject fire = GameObject.Instantiate(fire_prefab) as GameObject;
            fire.SetActive(true);
            
            Fire fireBehaviour=fire.GetComponent<Fire>();
            fireBehaviour.x_pos = x_pos-1;
            fireBehaviour.y_pos = y_pos;
            real_fires.Enqueue(fire);

            foreach (Isometric2DMovement player in list_of_players){
                if (player.x_pos == x_pos -1 && player.y_pos == y_pos){
                    player.dead=true;
                    Isometric2DMovement.gameOver = true;
                    // death or attack animation
                }
            }
        }
        else if (dir == 13){
            GameObject fire = GameObject.Instantiate(fire_prefab) as GameObject;
            fire.SetActive(true);

            Fire fireBehaviour=fire.GetComponent<Fire>();
            fireBehaviour.x_pos = x_pos;
            fireBehaviour.y_pos = y_pos-1;
            real_fires.Enqueue(fire);
            foreach (Isometric2DMovement player in list_of_players){
                if (player.x_pos == x_pos  && player.y_pos == y_pos - 1){
                    player.dead=true;
                    Isometric2DMovement.gameOver = true;
                    // death or attack animation
                }
            }
        }
        else if (dir == 14){
            GameObject fire = GameObject.Instantiate(fire_prefab) as GameObject;
            fire.SetActive(true);
            real_fires.Enqueue(fire);
            Fire fireBehaviour=fire.GetComponent<Fire>();
            fireBehaviour.x_pos = x_pos+1;
            fireBehaviour.y_pos = y_pos;
            foreach (Isometric2DMovement player in list_of_players){
                if (player.x_pos == x_pos + 1 && player.y_pos == y_pos){
                    player.dead=true;
                    Isometric2DMovement.gameOver = true;
                    // death or attack animation
                }
            }
        }
        
        target.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f);

    }
}
