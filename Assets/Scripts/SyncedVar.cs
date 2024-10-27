using UnityEngine;
using Photon.Pun;

public class SyncVariableExample : MonoBehaviourPun
{
    public static bool player1lose;
    public static bool player2lose;

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            
            player1lose=false;
            player2lose=false;
            UpdateSyncedValue(player1lose);
            UpdateSyncedValue(player2lose);
        }
    }

    [PunRPC]
    public void updateWinLoss(bool p1, bool p2){
    {
        player1lose = p1;
        player2lose=p2;
    }

}
