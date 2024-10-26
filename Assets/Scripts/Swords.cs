using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : MonoBehaviour
{
    public Camera cam;

    public Vector2 mousePos;     
    Queue<Action> player_inputs = new Queue<Action>();
    int delay_by_frames = Action.MAX_DELAY;

    float lastAngle = -1;

    void Start() {
        cam = Camera.main;
    }

    void Update() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookdir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;

        if (angle != lastAngle){
            player_inputs.Enqueue(new Action(Time.frameCount+delay_by_frames, new Vector3(0, 0, angle)));
            lastAngle = angle;
        }
        
        if (player_inputs.Count!=0 && player_inputs.Peek().frame_delay==Time.frameCount){
            Vector3 input = player_inputs.Dequeue().input;
            
            transform.rotation = Quaternion.Euler(input);
        }
    }
}
