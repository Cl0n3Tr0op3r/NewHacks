using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro; 

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    // Input field for the player to enter the room name they want to create.
    public TMP_InputField createInput;
    // Input field for the player to enter the room name they want to join.
    public TMP_InputField joinInput;

    // Called when the player wants to create a room.
    public void CreateRoom()
    {
        // Creates a new room with the name entered in the createInput field.
        PhotonNetwork.CreateRoom(createInput.text);
    }

    // Called when the player wants to join an existing room.
    public void JoinRoom()
    {
        // Joins an existing room with the name entered in the joinInput field.
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    // Callback when the player successfully joins a room.
    public override void OnJoinedRoom()
    {
        // Loads the main gameplay scene after joining the room.
        PhotonNetwork.LoadLevel("DefaultScene");
    }
}
