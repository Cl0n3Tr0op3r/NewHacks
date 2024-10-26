using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public float cameraSpeed=0.5f;
    public float elevation = -10f;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = new Vector3(player.position.x+3, player.position.y+3, elevation);
        transform.position = Vector3.Slerp(transform.position, cameraPos, cameraSpeed);

    }
}
