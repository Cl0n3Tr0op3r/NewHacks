using UnityEngine;
using System;

public class Isometric2DMovement : MonoBehaviour
{
    [SerializeField] private int x_pos;
    [SerializeField] private int y_pos;
    void Start(){
        transform.position=new Vector3(0f,0f,0f);
    }

    void Update()
    {  


        Vector3 pos = transform.position;
        if (Input.GetKeyDown("w")){
            y_pos+=1;
        }
        else if (Input.GetKeyDown("s")){
             y_pos-=1;
        }
        else if (Input.GetKeyDown("a")){
             x_pos-=1;
        }
        else if (Input.GetKeyDown("d")){
            x_pos+=1;
        }
        

        
        transform.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f);

    }
}
