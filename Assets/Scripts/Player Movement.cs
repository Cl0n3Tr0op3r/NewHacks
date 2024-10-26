using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float speed = 8f;

    // Update is called once per frame
    void Update()
    {
       Vector3 pos = transform.position;

       if (Input.GetKey("up")){
        pos.y += speed * Time.deltaTime;
       }
       if (Input.GetKey("down")){
        pos.y -= speed * Time.deltaTime;
       }
       if (Input.GetKey("left")){
        pos.x -= speed * Time.deltaTime;
       }
       if (Input.GetKey("right")){
        pos.x += speed * Time.deltaTime;
       }

       transform.position = pos;
    }
}
