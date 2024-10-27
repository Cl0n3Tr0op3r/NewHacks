using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    public int x_dir; // x_dir == 1, -1 or 0
    public int y_dir; // y_dir == 1, -1 or 0
    public Isometric2DMovement caller;

    public Attack(int x_dir, int y_dir, Isometric2DMovement caller){
        this.x_dir = x_dir;
        this.y_dir = y_dir;
        this.caller = caller;
    }

    public void attack_player(){
        foreach (Isometric2DMovement player in Isometric2DMovement.list_of_players){
            if (player.x_pos == caller.x_pos + x_dir && player.y_pos == caller.y_pos + y_dir){
                player.dead=true;
                Isometric2DMovement.gameOver = true;
            }
        }
    }
}
