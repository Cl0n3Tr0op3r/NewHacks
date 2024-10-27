using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject player1_fire_Prefab;
    public GameObject player2_fire_Prefab;
    public GameObject player1_fireghost_Prefab;
    public GameObject player2_fireghost_Prefab;

    
    public GameObject player1_ghost_Prefab;
    public GameObject player2_ghost_Prefab;

    public int x1;
    public int y1;
    public int x2;
    public int y2;

    private void Start()
    {
        GameObject playerPrefab;
        GameObject firePrefab;
        GameObject fireghostPrefab;
        GameObject ghostPrefab;

        

        // Check if the player is the first one or the second one to join
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            // First player joins as Player 1
            playerPrefab = player1Prefab;
            firePrefab = player1_fire_Prefab;
            fireghostPrefab = player1_fireghost_Prefab;
            ghostPrefab = player1_ghost_Prefab;
        }
        else
        {
            // Second player joins as Player 2
            playerPrefab = player2Prefab;
            firePrefab = player2_fire_Prefab;
            fireghostPrefab = player2_fireghost_Prefab;
            ghostPrefab = player2_ghost_Prefab;
        }

        // Instantiate the player
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(0f, 0f), Quaternion.identity);
        player.GetComponent<Isometric2DMovement>().x_pos = x2;
        player.GetComponent<Isometric2DMovement>().y_pos = y2;

        // Instantiate the ghost and set it inactive
        GameObject ghost = PhotonNetwork.Instantiate(ghostPrefab.name, new Vector2(0f, 0f), Quaternion.identity);
        ghost.GetComponent<GhostBehaviour>().x_pos = player.GetComponent<Isometric2DMovement>().x_pos;
        ghost.GetComponent<GhostBehaviour>().y_pos = player.GetComponent<Isometric2DMovement>().y_pos;
        ghost.SetActive(false);

        // Instantiate the fire and set it inactive
        GameObject instantiatedFire = PhotonNetwork.Instantiate(firePrefab.name, new Vector2(0f, 0f), Quaternion.identity);
        instantiatedFire.SetActive(false);

        // Instantiate the fire ghost and set it inactive
        GameObject instantiatedGhostFire = PhotonNetwork.Instantiate(fireghostPrefab.name, new Vector2(0f, 0f), Quaternion.identity);
        instantiatedGhostFire.SetActive(false);
    }
}
