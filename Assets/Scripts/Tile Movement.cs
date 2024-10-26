using UnityEngine;
using System;

public class Isometric2DMovement : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite[] spriteArray;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {  
        Vector3 pos =transform.position;
        if (Input.GetKeyDown("w")){
            pos = new Vector3((float)(transform.position.x + 0.5), (float)(transform.position.y + 0.25), 0f);
            spriteRenderer.sprite = spriteArray[1];
        }
        else if (Input.GetKeyDown("s")){
             pos = new Vector3((float)(transform.position.x - 0.5), (float)(transform.position.y - 0.25), 0f);
            spriteRenderer.sprite = spriteArray[3];

        }
        else if (Input.GetKeyDown("a")){
             pos = new Vector3((float)(transform.position.x - 0.5), (float)(transform.position.y + 0.25), 0f);
            spriteRenderer.sprite = spriteArray[2];

        }
        else if (Input.GetKeyDown("d")){
             pos = new Vector3((float)(transform.position.x + 0.5), (float)(transform.position.y - 0.25), 0f);
            spriteRenderer.sprite = spriteArray[0];
        
        }
        
        
        transform.position=pos;

    }
}
