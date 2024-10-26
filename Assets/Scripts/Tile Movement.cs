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
        // Get input axes
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        // Create the movement direction
        Vector2 moveDirection = new Vector2(horizontal, vertical);

        // Initialize isometric direction
        Vector2 isometricDirection = Vector2.zero;

        // Determine the isometric direction based on input
        if (moveDirection != Vector2.zero)
        {
            // Slanted up movement
            if (vertical > 0)
            {
                isometricDirection = new Vector2(moveDirection.x, moveDirection.y) * new Vector2(1, 0.5f);
            }
            // Slanted down movement
            else if (vertical < 0)
            {
                isometricDirection = new Vector2(moveDirection.x, moveDirection.y) * new Vector2(1, -0.5f);
            }

            // Normalize the direction
            isometricDirection.Normalize();
        }

        // Move the character
        transform.position += (Vector3)isometricDirection * moveSpeed * Time.deltaTime;
    }
}
