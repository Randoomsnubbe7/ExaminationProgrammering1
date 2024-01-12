using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;          // Speed of vertical movement
    public float shootingInterval = 2f;   // Time interval between shots
    public float bulletSpeed = 5f;        // Speed of bullets
    public GameObject bulletPrefab;
    public AudioClip deathSound;

    private Transform player;
    private AudioSource audioSource;
    private int hitPoints = 2;            // Number of hit points
    private bool wasHit = false;          // Track if the enemy was hit

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Ensure there's an AudioSource component on the GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If there's no AudioSource, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Start shooting and moving coroutine
        StartCoroutine(ShootAtPlayer());
        StartCoroutine(MoveUpDown());
    }

    IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            // Ensure that the bulletPrefab is not null
            if (bulletPrefab != null)
            {
                // Instantiate a bullet and shoot it towards the player
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                bulletScript.ShootBullet((player.position - transform.position).normalized, bulletSpeed);

                yield return new WaitForSeconds(shootingInterval);
            }
            else
            {
                Debug.LogError("Bullet prefab is null. Please assign a bullet prefab in the Inspector.");
                yield break;  // Exit the coroutine if the bulletPrefab is not set
            }
        }
    }

    IEnumerator MoveUpDown()
    {
        while (true)
        {
            // Move the enemy up and down
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            yield return new WaitForSeconds(1f); // Adjust this delay based on your desired movement frequency

            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            yield return new WaitForSeconds(1f); // Adjust this delay based on your desired movement frequency
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet") && !wasHit)
        {
            // Ensure that the audioSource is not null
            if (audioSource != null)
            {
                // Handle enemy hit logic
                Boolet bulletScript = other.GetComponent<Boolet>();
                if (bulletScript != null)
                {
                    Destroy(other.gameObject);  // Destroy the player's bullet
                    hitPoints--;

                    if (hitPoints <= 0)
                    {
                        wasHit = true;  // Prevent further damage
                        Die();
                    }
                }
            }
            else
            {
                Debug.LogError("AudioSource is null. Please ensure there's an AudioSource component on the enemy GameObject.");
            }
        }
    }

    void Die()
    {
        // Ensure that audioSource and deathSound are not null
        if (audioSource != null && deathSound != null)
        {
            // Play death sound
            audioSource.PlayOneShot(deathSound);
        }

        // Add any other death-related logic here
        Destroy(gameObject);  // Destroy the enemy
    }
}
