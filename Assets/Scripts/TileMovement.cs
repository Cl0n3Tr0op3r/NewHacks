using UnityEngine;
using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Isometric2DMovement : MonoBehaviour
{
    public int x_pos;

    private SyncedVar syncedVar;
    public int y_pos;
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite[] spriteArray;
    TilemapMapGenerator map;
    public bool dead;
    public static bool gameOver;
    public int orientation;


    public Queue<int> player_inputs = new Queue<int>();
    [SerializeField] public GameObject ghost;
    [SerializeField] public GameObject firePrefab;
    public Queue<GameObject> real_fires = new Queue<GameObject>();
    [SerializeField] public bool isPlayer;

    public static Isometric2DMovement[] list_of_players = new Isometric2DMovement[2];


    void Start()
    {
        PauseHandler.isTimePaused = true;
        transform.position=new Vector3(0f,0f,0f);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        map = GameObject.Find("Grid").GetComponent<TilemapMapGenerator>();
       

        if (list_of_players[0]==null){
            list_of_players[0]=this;
        }
        else{
            list_of_players[1]=this;
        }
      
        

    }

    void Update()
    {  
        if (dead){
            gameObject.SetActive(false);
            SceneManager.LoadScene("Winner");
        }


    
        transform.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f );
        if(isPlayer){
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PauseHandler.isTimePaused=!PauseHandler.isTimePaused;
                ghost.gameObject.SetActive(false);
                ghost.GetComponent<GhostBehaviour>().updateRemainTurns(6);
                foreach (var fire in FireGhost.all_fires){
                    // print(fire);
                    if (fire!=null){
                        Destroy(fire.gameObject, 0f);
                        
                    }
                }
                FireGhost.counter=0;
                
            }
            if (!PauseHandler.isTimePaused)
            {
                
                ghost.GetComponent<GhostBehaviour>().x_pos = x_pos;
                ghost.GetComponent<GhostBehaviour>().y_pos = y_pos;
                ghost.transform.position = this.transform.position;

                if (player_inputs.Count != 0) {
                    
                    if(player_inputs.Count != 0 && Time.frameCount % 200 == 0){
                        
                        move(player_inputs.Dequeue());
                        
                    }
                }
                if(real_fires.Count != 0){
                    Destroy(real_fires.Dequeue().gameObject, 0.8f);
                }

            }
            else
            {
                int temp_x_pos = x_pos;
                int temp_y_pos = y_pos;
              
                if(real_fires.Count!=0 && Time.frameCount % 30 == 0){
                    Destroy(real_fires.Dequeue().gameObject, 0f);
                }
                
                if (ghost.GetComponent<GhostBehaviour>().remTurns <= 0)
                {
                    return;
                }
                

                ghost.SetActive(true);
                
                
                SpriteRenderer pauseMoveIndicatorSprite = ghost.GetComponent<SpriteRenderer>();

                if (Input.GetKeyDown("w")) 
                {
                    if((map.end_y)>=temp_y_pos){
                        temp_y_pos+=1;
                        player_inputs.Enqueue(1);
                    }
            
                    

                }
                else if (Input.GetKeyDown("a")) 
                {
                    if(map.start_y+2<temp_y_pos){
                        temp_y_pos-=1;
                        player_inputs.Enqueue(2);
                    }
                }
                else if (Input.GetKeyDown("s")) 
                {
                    if(map.start_x<=temp_x_pos){
                         temp_x_pos-=1;
                        player_inputs.Enqueue(3);
                    }
                    
                }
                else if (Input.GetKeyDown("d")) 
                {
                    if((-2+map.end_x)>temp_x_pos){
                         temp_x_pos+=1;
                        player_inputs.Enqueue(4);
                    }
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
                else if (Input.GetKeyDown("right")){
                    player_inputs.Enqueue(14);
                }
            }
        }
        else{

            
            if (!PauseHandler.isTimePaused)
            {
                
                ghost.GetComponent<GhostBehaviour>().x_pos = x_pos;
                ghost.GetComponent<GhostBehaviour>().y_pos = y_pos;
                ghost.transform.position = this.transform.position;

                if (player_inputs.Count != 0) {
                    
                    if(player_inputs.Count != 0 && Time.frameCount % 200 == 0){
                        
                        move(player_inputs.Dequeue());
                        
                    }
                }
                if(real_fires.Count != 0){
                    Destroy(real_fires.Dequeue().gameObject, 0.8f);
                }

            }
            else
            {
              
                if(real_fires.Count!=0 && Time.frameCount % 30 == 0){
                    Destroy(real_fires.Dequeue().gameObject, 0f);
                }
                
                if (ghost.GetComponent<GhostBehaviour>().remTurns <= 0)
                {
                    return;
                }
                

                ghost.SetActive(true);
                
                
                SpriteRenderer pauseMoveIndicatorSprite = ghost.GetComponent<SpriteRenderer>();

                if(!isPlayer){
                    System.Random rnd = new System.Random();
                    int temp_x_pos = x_pos;
                    int temp_y_pos = y_pos;
                    int[] possible_moves = {1,2,3,4,11,12,13,14};
                    while(player_inputs.Count!=6){
                        int next_move = rnd.Next(0,7);
                        if (next_move == 1){
                            if((map.end_y)>=temp_y_pos){
                                temp_y_pos+=1;
                                player_inputs.Enqueue(possible_moves[next_move]);
                            } 
                        }
                        else if (next_move == 3){
                            if(map.start_y+2<temp_y_pos){
                                temp_y_pos-=1;
                                player_inputs.Enqueue(possible_moves[next_move]);
                            }
                        }
                        else if (next_move == 2){
                            if(map.start_x<=temp_x_pos){
                                temp_x_pos-=1;
                                player_inputs.Enqueue(possible_moves[next_move]);
                            }
                            
                        }
                        else if (next_move == 4){
                            if((-2+map.end_x)>temp_x_pos){
                                temp_x_pos+=1;
                                player_inputs.Enqueue(possible_moves[next_move]);
                            }
                        }
                        else{
                            player_inputs.Enqueue(possible_moves[next_move]);
                        }
                        
                    }
                    Debug.Log(player_inputs.Count);
                    
                }
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
        
        if (gameOver==true){
            if(list_of_players[0].dead){
                Debug.Log("Player 2 wins");
            }
            else{
                Debug.Log("Player 1 wins");
            }
        }


        if (dir == 1){
            if((map.end_y)>=y_pos){
                y_pos+=1;
            }
            orientation=1;
            spriteRenderer.sprite = spriteArray[1];
        }
        else if (dir == 3){
            if(map.start_y+2<y_pos){
                y_pos-=1;
            }
            orientation=3;
            spriteRenderer.sprite = spriteArray[3];
        }
        else if (dir == 2){
            if(map.start_x<=x_pos){
                x_pos-=1;
            }
            orientation=2;
            spriteRenderer.sprite = spriteArray[2];
        }
        else if (dir == 4){
            if((-2+map.end_x)>x_pos){
                x_pos+=1;
            }
            orientation=4;
            
            spriteRenderer.sprite = spriteArray[0];   
        }

        else if (dir == 11){

            GameObject fire = Instantiate(firePrefab, new Vector2(0f, 0f), Quaternion.identity);

            Fire fireBehaviour = fire.GetComponent<Fire>(); 
            real_fires.Enqueue(fire);
            fireBehaviour.x_pos = x_pos;
            fireBehaviour.y_pos = y_pos+1;
            
            fire.SetActive(true);
            Isometric2DMovement[] list_of_players = Isometric2DMovement.list_of_players;
            foreach (Isometric2DMovement player in list_of_players){
                if (player.x_pos == x_pos  && player.y_pos == y_pos+1 ){
                player.dead=true;
                Isometric2DMovement.gameOver = true;
                Debug.Log("dead");
                
                }
            }            
            
          
        }
        else if (dir == 12){

            GameObject fire = Instantiate(firePrefab, new Vector2(0f, 0f), Quaternion.identity);

            Fire fireBehaviour = fire.gameObject.GetComponent<Fire>();
            real_fires.Enqueue(fire);
            Debug.Log(fireBehaviour);
            fireBehaviour.x_pos = x_pos-1;
            fireBehaviour.y_pos = y_pos;
            
            fire.SetActive(true);
            Isometric2DMovement[] list_of_players = Isometric2DMovement.list_of_players;
            foreach (Isometric2DMovement player in list_of_players){
                if (player.x_pos == x_pos-1  && player.y_pos == y_pos ){
                player.dead=true;
                Isometric2DMovement.gameOver = true;
                Debug.Log("dead");
                
                }
            }    
        }
        else if (dir == 13){

            GameObject fire = Instantiate(firePrefab, new Vector2(0f, 0f), Quaternion.identity);

            Fire fireBehaviour=fire.GetComponent<Fire>();
            real_fires.Enqueue(fire);
            fireBehaviour.x_pos = x_pos;
            fireBehaviour.y_pos = y_pos-1;
            Isometric2DMovement[] list_of_players = Isometric2DMovement.list_of_players;
            fire.SetActive(true);
            foreach (Isometric2DMovement player in list_of_players){
                if (player.x_pos == x_pos+1  && player.y_pos == y_pos ){
                player.dead=true;
                Isometric2DMovement.gameOver = true;
                Debug.Log("dead");
                
                }
            }    
        }
        else if (dir == 14){

            GameObject fire = Instantiate(firePrefab, new Vector2(0f, 0f), Quaternion.identity);

            Fire fireBehaviour=fire.GetComponent<Fire>();
            real_fires.Enqueue(fire);
            fireBehaviour.x_pos = x_pos+1;
            fireBehaviour.y_pos = y_pos;
            Isometric2DMovement[] list_of_players = Isometric2DMovement.list_of_players;
            fire.SetActive(true);
            
            foreach (Isometric2DMovement player in list_of_players){
                if (player.x_pos == x_pos  && player.y_pos == y_pos-1 ){
                player.dead=true;
                Isometric2DMovement.gameOver = true;
                Debug.Log("dead");
                
                }
            }    
        }
        
        target.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f );

        }
    
}
