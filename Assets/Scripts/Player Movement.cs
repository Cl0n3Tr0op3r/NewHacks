using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    
    Queue<Action> player_inputs = new Queue<Action>();
    float speed = 3f;
    int delay_rate = 1;
    int delay_by_frames = 100;
    BoxCollider2D boxCollider;

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
       if (pos!=Vector3.zero){
        player_inputs.Enqueue(new Action(Time.frameCount+delay_by_frames, pos));
       }
       



       if (player_inputs.Count!=0 && player_inputs.Peek().frame_delay==Time.frameCount){
            Vector3 input = player_inputs.Dequeue().input;
            if (input.x>0==transform.localScale.x>0){
                
                 Vector3 flip = transform.localScale;
                 flip.x *= -1;
                 transform.localScale = flip;
            }
            Vector3 new_position = transform.position + input;  
            
            transform.position += input;
            
       }
    }
}


public class Action{
     public int frame_delay;
     public Vector3 input;

    
     public Action(int frame_delay, Vector3 input){
          this.frame_delay=frame_delay;
          this.input=input;
     }
}