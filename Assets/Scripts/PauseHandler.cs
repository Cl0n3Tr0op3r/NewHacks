using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    public static bool isTimePaused;

    public void revertTime(){
        Isometric2DMovement[] players =  Isometric2DMovement.list_of_players;
        if (players[0]== false && players[1]==false){
            isTimePaused=false;
        }
    }
}
