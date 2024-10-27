using UnityEngine;
using System;
using System.Collections.Generic;
using Cinemachine;
using TMPro;


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
    [SerializeField] public GameObject father_ghost;
    public Queue<int> player_inputs = new Queue<int>();
    [SerializeField] public GameObject fire_ghost;

    [SerializeField] public TMP_Text turnsDisplay;


    public static LinkedList<GhostBehaviour> list_of_players = new LinkedList<GhostBehaviour>();


    void Start()
    {
        yourTurn=true;
        
        //

        startPos = (x_pos, y_pos);
        remTurns=6;
        updateRemainTurns(remTurns);

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
            if (remTurns != 0){
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
                }
                else if (Input.GetKeyDown("d")) 
                {
                    move(4);
                
                }
                else if (Input.GetKeyDown("up")){
                    move(11);
                    remTurns--;
                }
                else if (Input.GetKeyDown("left")){
                    move(12);
                    remTurns--;
                }
                else if (Input.GetKeyDown("down")){
                    move(13);
                    remTurns--;
                }
                else if (Input.GetKeyDown("right")){
                    move(14);
                    remTurns--;
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Escape)){
                updateRemainTurns(6);
                Isometric2DMovement parent = father_ghost.GetComponent<Isometric2DMovement>();
                player_inputs.Clear();
                x_pos = parent.x_pos;
                y_pos = parent.y_pos;
                transform.position = parent.transform.position;
                foreach (var fire in FireGhost.all_fires){
                    if (fire!=null){
                        Destroy(fire.gameObject);
                    }
                }
                FireGhost.counter=0;

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
            GameObject fire = GameObject.Instantiate(fire_ghost) as GameObject;
            fire.SetActive(true);
            FireGhost.all_fires[FireGhost.counter]=fire;
            FireGhost.counter++;
            FireGhost fireBehaviour = fire.GetComponent<FireGhost>(); 
            fireBehaviour.x_pos = x_pos;
            fireBehaviour.y_pos = y_pos+1;
        }
        else if (dir == 12){
            GameObject fire = GameObject.Instantiate(fire_ghost) as GameObject;
            FireGhost fireBehaviour = fire.GetComponent<FireGhost>(); 
            fire.SetActive(true);
            FireGhost.all_fires[FireGhost.counter]=fire;
            FireGhost.counter++;
            fireBehaviour.x_pos = x_pos - 1;
            fireBehaviour.y_pos = y_pos;
        }
        else if (dir == 13){
            GameObject fire = GameObject.Instantiate(fire_ghost) as GameObject;
            FireGhost fireBehaviour = fire.GetComponent<FireGhost>(); 
            fire.SetActive(true);
            FireGhost.all_fires[FireGhost.counter]=fire;
            FireGhost.counter++;
            fireBehaviour.x_pos = x_pos;
            fireBehaviour.y_pos = y_pos -1;
        }
        else if (dir == 14){
            GameObject fire = GameObject.Instantiate(fire_ghost) as GameObject;
            fire.SetActive(true);
            FireGhost.all_fires[FireGhost.counter]=fire;
            FireGhost.counter++;
            FireGhost fireBehaviour = fire.GetComponent<FireGhost>(); 
            fireBehaviour.x_pos = x_pos +1;
            fireBehaviour.y_pos = y_pos;
        }
        updateRemainTurns(remTurns - 1);

        // else if (dir == 11){
        //     Debug.Log("");
        // }
        // else if (dir == 12){
        //     Debug.Log("");
        // }
        // else if (dir == 13){
        //    Debug.Log("");
        // }
        // else if (dir == 14){
        //     Debug.Log("");
        // }
        
        target.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f);

    }

    void updateRemainTurns(int left) 
    {
        this.remTurns = left;
        turnsDisplay.text = "Moves: " + left.ToString();
    }
}
