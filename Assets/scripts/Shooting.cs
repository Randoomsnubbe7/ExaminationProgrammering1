using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public AudioClip shootSound;
    public AudioClip hitSound;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Move the bullet forward
        rb.velocity = transform.right * bulletSpeed; // Use transform.right for 2D forward direction
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Play hit sound when the bullet collides with something
        audioSource.PlayOneShot(hitSound);

        // Destroy the bullet on collision
        Destroy(gameObject);
    }

    public void Shoot()
    {
        // Instantiate the bullet and play shoot sound
        GameObject bullet = Instantiate(gameObject, transform.position, transform.rotation);
        audioSource.PlayOneShot(shootSound);

        // Ignore collisions between the player and their own bullets
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
    }
}
