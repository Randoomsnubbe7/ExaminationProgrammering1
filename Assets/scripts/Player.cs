using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;

    public float moveSpeed = 5f;
    public LayerMask groundLayer;

    private bool isGrounded;

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Check if the player has touched the ground, and if so, "kill" the player
        if (isGrounded)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement your death logic here, such as playing a death animation, disabling controls, or respawning
        Debug.Log("Player has touched the ground and died!");
        // For simplicity, we'll just deactivate the GameObject
        gameObject.SetActive(false);
    }
}
