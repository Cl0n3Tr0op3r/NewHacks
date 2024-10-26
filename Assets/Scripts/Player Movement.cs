using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    
    Queue<Action> player_inputs = new Queue<Action>();
<<<<<<< HEAD
    float speed = 5f;
    int delay_rate = 1;
    int delay_by_frames = 0;
=======
    float speed = 3f;
    int delay_by_frames = Action.MAX_DELAY;
>>>>>>> 740f8e40dc8d695596500ca55ea79ad5a7f27385
    BoxCollider2D boxCollider;

    void Start(){
          // boxCollider=GameObject.Find("Game Boundaries").GetComponent<BoxCollider2D>();
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
       if (pos!=Vector3.zero){
        player_inputs.Enqueue(new Action(Time.frameCount+delay_by_frames, pos));
       }
<<<<<<< HEAD
       

          // TODO: Scale up delay from 0 to frame_delay from start of match to reduce clunkiness

=======
>>>>>>> 740f8e40dc8d695596500ca55ea79ad5a7f27385
       if (player_inputs.Count!=0 && player_inputs.Peek().frame_delay==Time.frameCount){
            Vector3 input = player_inputs.Dequeue().input;
            if (input.x>0==transform.localScale.x>0){
                
                 Vector3 flip = transform.localScale;
                 flip.x *= -1;
                 transform.localScale = flip;
            }
            Vector3 new_pos = transform.position + input;  
           
            if ((-23<=new_pos.x && new_pos.x<=23) && (-14<=new_pos.y && new_pos.y <= 12.5)){
                transform.position += input;
            }
            
       }
    }
}


public class Action{
     public int frame_delay;
     public Vector3 input;

    
     public Action(int frame_delay, Vector3 input){
          int delta = Action.MAX_DELAY;
          if (frame_delay > 2000)
          {
               delta /= (int)(frame_delay / 2000);
          }

          this.frame_delay=frame_delay - delta;
          this.input=input;
     }

     public static int MAX_DELAY = 200;
}