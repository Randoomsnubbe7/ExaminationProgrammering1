using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3; // Set initial health

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

        // Check if the player has touched the ground, and if so, "take damage"
        if (isGrounded)
        {
            TakeDamage(1); // You can customize the damage amount
        }
    }

    void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        // Check if the player has run out of health
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement your death logic here, such as playing a death animation, disabling controls, or respawning
        Debug.Log("Player has run out of health and died!");
        // For simplicity, we'll just deactivate the GameObject
        gameObject.SetActive(false);
    }
}

