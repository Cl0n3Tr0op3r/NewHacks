using UnityEngine;
using System;

public class Isometric2DMovement : MonoBehaviour
{

    void Update()
    {  
        Vector3 pos =transform.position;
        if (Input.GetKeyDown("w")){
             pos = new Vector3((float)(transform.position.x + 0.5), (float)(transform.position.y+0.25), 0f);
        }
        else if (Input.GetKeyDown("s")){
             pos = new Vector3((float)(transform.position.x - 0.5), (float)(transform.position.y - 0.25), 0f);
        }
        else if (Input.GetKeyDown("a")){
             pos = new Vector3((float)(transform.position.x - 0.5), (float)(transform.position.y + 0.25), 0f);
        }
        else if (Input.GetKeyDown("d")){
             pos = new Vector3((float)(transform.position.x + 0.5), (float)(transform.position.y - 0.25), 0f);
        
        }
        
        
        transform.position=pos;

    }
}
