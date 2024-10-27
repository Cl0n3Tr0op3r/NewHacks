using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public float x1;
    public float y1;
    public float x2;
    public float y2;

    private void Start()
    {
        GameObject playerPrefab;
        Vector2 spawnPosition;

        // Check if the player is the first one or the second one to join
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            // First player joins as Player 1
            playerPrefab = player1Prefab;
            spawnPosition = new Vector2(x1, y1);
        }
        else
        {
            // Second player joins as Player 2
            playerPrefab = player2Prefab;
            spawnPosition = new Vector2(x2, y2);
        }

        // Instantiate the chosen player prefab at the specified position
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
    }
}

