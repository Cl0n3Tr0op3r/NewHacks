using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    
<<<<<<< HEAD
    Queue<Action> player_inputs = new Queue<Action>();
    float speed = 5f;
  

    int delay_by_frames = Action.MAX_DELAY;
    BoxCollider2D boxCollider;
=======
    float speed = 3f;
>>>>>>> 5a3efca8be7aacec7adddb983ec45d3b6ba5cdc6

    void Start(){
          boxCollider=GameObject.Find("Game Boundaries").GetComponent<BoxCollider2D>();
          Application.targetFrameRate=60;

    }
    

    // Update is called once per frame
    void Update()
    {
       Vector3 pos = new Vector3();

       if (Input.GetKey("up")){
        pos.y = speed * Time.deltaTime;
       }
       if (Input.GetKey("down")){
        pos.y = speed * Time.deltaTime * -1;
       }
       if (Input.GetKey("left")){
        pos.x = speed * Time.deltaTime * -1;
       }
       if (Input.GetKey("right")){
        pos.x = speed * Time.deltaTime;
       }
<<<<<<< HEAD
       if (pos!=Vector3.zero){
        player_inputs.Enqueue(new Action(Time.frameCount+delay_by_frames, pos));
       }
       

          // TODO: Scale up delay from 0 to frame_delay from start of match to reduce clunkiness

       if (player_inputs.Count!=0 && player_inputs.Peek().frame_delay==Time.frameCount){
            Vector3 input = player_inputs.Dequeue().input;
            if (input.x>0==transform.localScale.x>0){
                
                 Vector3 flip = transform.localScale;
                 flip.x *= -1;
                 transform.localScale = flip;
            }
            Vector3 new_pos = transform.position + input;  
          
            if ((-23<=new_pos.x && new_pos.x<=23) && (-14<=new_pos.y && new_pos.y <= 12.5)){ // border size
                transform.position += input; 
            }
            
       }
=======
       
       transform.position += pos;
>>>>>>> 5a3efca8be7aacec7adddb983ec45d3b6ba5cdc6
    }


}

<<<<<<< HEAD

public class Action{
     public int frame_delay;
     public Vector3 input;
     public static bool firstAction=false;
     public static int startFrameCount;
     public static int MAX_DELAY = 50;
     public static bool pastNoDelayPeriod = false;
    
     public Action(int frame_delay, Vector3 input){
          /* firstAction=true;
          startFrameCount=Time.frameCount;
          frame_delay = Action.MAX_DELAY;
          */
          this.input=input;
          this.frame_delay=frame_delay;
          /*
          if ( !pastNoDelayPeriod && frame_delay - Time.frameCount < 300 ){
               frame_delay = (int)((frame_delay - Time.frameCount) / MAX_DELAY);

          }
          else{
               pastNoDelayPeriod=true;
               this.frame_delay = frame_delay;
          }
          */
          
     }

     
}
     
=======
>>>>>>> 5a3efca8be7aacec7adddb983ec45d3b6ba5cdc6
