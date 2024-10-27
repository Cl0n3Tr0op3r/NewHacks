using UnityEngine;
using Photon.Pun;

public class SyncedVar : MonoBehaviourPun
{
    public static bool player1lose;
    public static bool player2lose;

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {   
            player1lose=false;
            player2lose=false;
            updateWinLoss(player1lose,player2lose);
        }
    }

    [PunRPC]
    public static void updateWinLoss(bool p1, bool p2){
    {
        player1lose = p1;
        player2lose=p2;
    }

}
}
