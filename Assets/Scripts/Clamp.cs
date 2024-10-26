using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {   
        Vector3 pos = transform.position;
        transform.position = new Vector3(Mathf.Clamp(pos.x, -23f, 23f), Mathf.Clamp(pos.y, -14f, 12.5f),0f);
    }
}
