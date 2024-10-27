using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers2 : MonoBehaviour
{
    public GameObject player2Prefab;

    public float x2;
    public float y2;

    private void Start()
    {
        Vector3 spawnPosition = new Vector3(x2, y2);
        PhotonNetwork.Instantiate(player2Prefab.name, spawnPosition, Quaternion.identity);
    }
}
