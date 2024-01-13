using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    public Player player; // Reference to your player script (you may need to adjust this based on your actual player script)

    private Text healthText;

    void Start()
    {
        // Get the Text component attached to the same GameObject
        healthText = GetComponent<Text>();

        // Check if the Text component is found
        if (healthText == null)
        {
            Debug.LogError("PlayerHealthDisplay script requires a Text component!");
        }
    }

    void Update()
    {
        // Check if the player reference is set
        if (player != null)
        {
            // Update the displayed health value
            healthText.text = "Health: " + player.health.ToString();
        }
        else
        {
            // Display an error message if the player reference is not set
            healthText.text = "Player reference not set!";
        }
    }
}
