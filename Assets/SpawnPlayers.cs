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
    public GameObject player1_word_Prefab;
    public GameObject player2_word_Prefab;
    public GameObject player1_score_Prefab;
    public GameObject player2_score_Prefab;
    public GameObject player1_camera_Prefab;
    public GameObject player2_camera_Prefab;
    
    public GameObject player1_ghost_Prefab;
    public GameObject player2_ghost_Prefab;

    public float x1;
    public float y1;
    public float x2;
    public float y2;

    private void Start()
    {
        GameObject playerPrefab;
        GameObject firePrefab;
        GameObject fireghostPrefab;
        GameObject ghostPrefab;

        
        Vector2 spawnPosition;

        int x_pos;
        int y_pos;

        // Check if the player is the first one or the second one to join
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            // First player joins as Player 1
            playerPrefab = player1Prefab;
            firePrefab = player1_fire_Prefab;
            fireghostPrefab = player1_fireghost_Prefab;
            ghostPrefab = player1_ghost_Prefab;
            spawnPosition = new Vector2(x1, y1);
            x_pos = 1;
            y_pos = 2;
        }
        else
        {
            // Second player joins as Player 2
            playerPrefab = player2Prefab;
            firePrefab = player2_fire_Prefab;
            fireghostPrefab = player2_fireghost_Prefab;
            ghostPrefab = player2_ghost_Prefab;

            spawnPosition = new Vector2(x2, y2);
            x_pos = 2;
            y_pos = 3;
        }

        
        // Instantiate the chosen player prefab at the specified position
        GameObject instantiatedPlayer = PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
        GameObject instantiatedFire = PhotonNetwork.Instantiate(firePrefab.name, spawnPosition, Quaternion.identity);
        GameObject instantiatedGhostFire = PhotonNetwork.Instantiate(fireghostPrefab.name, spawnPosition, Quaternion.identity);
        GameObject instantiateGhost = PhotonNetwork.Instantiate(ghostPrefab.name, spawnPosition, Quaternion.identity);
      
        instantiatedPlayer.transform.position = new Vector3( (float)(y_pos * 0.5 + x_pos * 0.5), (float)(y_pos * 0.25 - x_pos *0.25),0f );


        instantiatedFire.SetActive(false);
        instantiatedGhostFire.SetActive(false);
        instantiateGhost.SetActive(false);
    }   
}
