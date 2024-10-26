using UnityEngine;

public class Isometric2DMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
      
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");     


        Vector2 moveDirection = Vector2.zero;

       
        if (horizontal != 0 || vertical != 0)
        {
       
            moveDirection = new Vector2(vertical, horizontal);
            
            
            Vector2 isometricDirection = new Vector2(
                moveDirection.x - moveDirection.y, 
                (moveDirection.x + moveDirection.y) * 0.5f
            );

           
            isometricDirection.Normalize();

         
            transform.position += (Vector3)isometricDirection * moveSpeed * Time.deltaTime;
        }
    }
}
