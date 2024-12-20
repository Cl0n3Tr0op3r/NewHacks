using UnityEngine;
using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public int x_pos;

    private SyncedVar syncedVar;
    public int y_pos;
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite[] spriteArray;
    TilemapMapGenerator map;
    public bool dead;
    public static bool gameOver;


    public Queue<int> player_inputs = new Queue<int>();
    [SerializeField] public GameObject ghost;
    [SerializeField] public GameObject firePrefab;
    public Queue<GameObject> real_fires = new Queue<GameObject>();
    public int frameDelay = 1;
    public static Isometric2DMovement[] list_of_players;



    void Start()
    {

        PauseHandler.isTimePaused = true;


        
        list_of_players=Isometric2DMovement.list_of_players;
        transform.position=new Vector3(0f,0f,0f);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        map = GameObject.Find("Grid").GetComponent<TilemapMapGenerator>();
       


      
        

    }

    void Update()
    {  
        if (dead){
            gameObject.SetActive(false);
            SceneManager.LoadScene("Winner");
        }


{
        transform.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f );

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
                
                if(player_inputs.Count != 0 && Time.frameCount % 30 == 0){
                    
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
            else if (Input.GetKeyDown("right")){
                player_inputs.Enqueue(14);
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

        GameObject fire = Instantiate(firePrefab, new Vector2(0f, 0f), Quaternion.identity);

        Fire fireBehaviour = fire.GetComponent<Fire>(); 
        real_fires.Enqueue(fire);
        fireBehaviour.x_pos = x_pos;
        fireBehaviour.y_pos = y_pos+1;
        
        fire.SetActive(true);
        Isometric2DMovement[] list_of_players = Isometric2DMovement.list_of_players;

        if (list_of_players[0].x_pos == x_pos+1  && list_of_players[0].y_pos == y_pos+1 ){
            list_of_players[0].dead=true;
            Isometric2DMovement.gameOver = true;
            SyncedVar.updateWinLoss(true, false);
                // death or attack animation
            
            
        }
        else if (list_of_players[1].x_pos == x_pos  && list_of_players[1].y_pos == y_pos +1){
            list_of_players[1].dead=true;
            Isometric2DMovement.gameOver = true;
            SyncedVar.updateWinLoss(false, true);
                // death or attack animation
            
            
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
        if (list_of_players[0].x_pos == x_pos  && list_of_players[0].y_pos == y_pos-1 ){
            list_of_players[0].dead=true;
            Isometric2DMovement.gameOver = true;
            gameOver=true;
            SceneManager.LoadScene("Winner");
                // death or attack animation
            
            
        }
        else if (list_of_players[1].x_pos == x_pos && list_of_players[1].y_pos == y_pos -1){
            list_of_players[1].dead=true;
            Isometric2DMovement.gameOver = true;
            gameOver=true;
            SceneManager.LoadScene("Winner");
            
            
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
        if (list_of_players[0].x_pos == x_pos-1  && list_of_players[0].y_pos == y_pos ){
            list_of_players[0].dead=true;
            Isometric2DMovement.gameOver = true;
            gameOver=true;
            SceneManager.LoadScene("Winner");
                // death or attack animation
            
            
        }
        else if (list_of_players[1].x_pos == x_pos-1  && list_of_players[1].y_pos == y_pos ){
            list_of_players[1].dead=true;
            Isometric2DMovement.gameOver = true;
            gameOver=true;
            SceneManager.LoadScene("Winner");
            
            
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
        
        if (list_of_players[0].x_pos == x_pos+1  && list_of_players[0].y_pos == y_pos ){
            list_of_players[0].dead=true;
            Isometric2DMovement.gameOver = true;
            gameOver=true;
            SceneManager.LoadScene("Winner");
                // death or attack animation
            
            
        }
        else if (list_of_players[1].x_pos == x_pos+1  && list_of_players[1].y_pos == y_pos ){
            list_of_players[1].dead=true;
            Isometric2DMovement.gameOver = true;
            gameOver=true;
            SceneManager.LoadScene("Winner");
            
            
        }
    }
    
    target.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f );

    }
}
