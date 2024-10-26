using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : MonoBehaviour
{
    public Camera cam;

    public Vector2 mousePos; 
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    void Start() {
        cam = Camera.main;
    }

    void Update() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookdir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    
    }
}
