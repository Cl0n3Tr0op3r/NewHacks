using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private int remActions;
    [SerializeField] private GameObject father_ghost;
    public int x_pos;
    public int y_pos;
    public int prev_x_pos;
    public int prev_y_pos;
    
    void Update()
    {
        if (isTimePaused){
            if (remActions!=0){
                if (Input.GetKeyDown("w")) move(1);
                if (Input.GetKeyDown("a")) move(2);
                if (Input.GetKeyDown("s")) move(3);
                if (Input.GetKeyDown("d")) move(4);
            }
            else{
                if (Input.GetKeyDown(KeyCode.Escape)){
                    remActions = 6;
                    x_pos = prev_x_pos;
                    y_pos = prev_y_pos; 
                }
            }
            
        }
        else{
            transform.position = father_ghost.transform.position;
            x_pos = father_ghost.GetComponent<Isometric2DMovement>().x_pos;
            y_pos = father_ghost.GetComponent<Isometric2DMovement>().y_pos;
            prev_x_pos = x_pos;
            prev_y_pos = y_pos;
        }
        
    }

    void move(int dir) {
        // dir    1 2 3 4
        // key    w a s d
        
        Vector3 pos = transform.position;
        
        if (dir == 1){
            if((map.end_y)>=y_pos){
                y_pos+=1;
            }
            spriteRenderer.sprite = spriteArray[1];
        }
        else if (dir == 3){
            if(map.start_y+2<y_pos){
                y_pos-=1;
            }
             spriteRenderer.sprite = spriteArray[3];
        }
        else if (dir == 2){
            if(map.start_x<=x_pos){
                x_pos-=1;
            }
             spriteRenderer.sprite = spriteArray[2];
        }
        else if (dir == 4){
            if((-2+map.end_x)>x_pos){
                x_pos+=1;
            }
            
            spriteRenderer.sprite = spriteArray[0];
            
        }
        
        transform.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f);

    }
}
