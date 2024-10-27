using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    public float x1;
    public float y1;
    public float x2;
    public float y2;

    private static bool hasSpawnedOnce = false;

    private void Start()
    {
        Vector2 spawnPosition;

        if (!hasSpawnedOnce)
        {
            spawnPosition = new Vector2(x1, y1);
            hasSpawnedOnce = true; 
        }
        else
        {
            spawnPosition = new Vector2(x2, y2);
        }

        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
    }
}
