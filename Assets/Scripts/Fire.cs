using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int x_pos;
    public int y_pos;
    public static GameObject[] all_fires = new GameObject[6];
    public static int counter=0;
    
    
    
    void Start(){
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.position=new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25) -0.4f,0f);

    
    }
}
