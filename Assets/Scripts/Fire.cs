using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int x_pos;
    public int y_pos;



    void Start()
    {
        x_pos=0;
        y_pos=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25) -0.4f,0f);

        
    }
}
