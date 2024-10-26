using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Queue<Vector3> player_inputs = new Queue<Vector3>();
    float speed = 8f;
    int delay_rate = 5;

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
        player_inputs.Enqueue(pos);
       }
       



       if (Time.frameCount % delay_rate == 0 && player_inputs.Count!=0){
            Vector3 input = player_inputs.Dequeue();
            if (input.x>0==transform.localScale.x>0){
                
                 Vector3 flip = transform.localScale;
                 flip.x *= -1;
                 transform.localScale = flip;
            }
            
            transform.position += input;
       }
    }
}
