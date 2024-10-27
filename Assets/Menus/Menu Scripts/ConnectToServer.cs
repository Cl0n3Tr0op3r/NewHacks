using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Called at the start of the game to connect to the Photon server using settings.
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    //Callback when the connection to the Photon master server is successful.
    public override void OnConnectedToMaster()
    {
        // Joins the default lobby after a successful connection.
        PhotonNetwork.JoinLobby();
    }

    // Callback when the player successfully joins a lobby.
    public override void OnJoinedLobby()
    {
        // Loads the "ServerMenu" scene where players can access options for creating or joining rooms.
        SceneManager.LoadScene("ServerMenu");
    }
}
