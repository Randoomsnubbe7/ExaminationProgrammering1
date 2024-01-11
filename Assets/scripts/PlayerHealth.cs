using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public int maxHealth = 5; // Maximum health points
    private int currentHealth;   // Current health points
    public TextMeshProUGUI healthText; // Reference to the TextMeshPro text component
    public string DeathScene;
    void Start()
    {
        currentHealth = maxHealth; // Set current health to maximum health when the object starts
        UpdateHealthText(); // Update the displayed health text
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth = Mathf.Max(0, currentHealth - damageAmount); // Reduce health by damageAmount

        if (currentHealth == 0)
        {
            SceneManager.LoadScene(DeathScene);
            Die(); // Call the Die method when health reaches zero
        }

        UpdateHealthText(); // Update the displayed health text after taking damage
    }

    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + healAmount); // Increase health by healAmount

        UpdateHealthText(); // Update the displayed health text after healing
    }

    private void Die()
    {
        SceneManager.LoadScene(DeathScene);
        Debug.Log(gameObject.name + " has died."); // Display a death message
        // Add more functionality here, like destroying the object or triggering game over
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString(); // Update the TextMeshPro text
        }
    }
}

    
