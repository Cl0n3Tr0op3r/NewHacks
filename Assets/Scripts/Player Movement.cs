using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    
    float speed = 3f;

    void Start(){
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
       
       transform.position += pos;
    }


}

