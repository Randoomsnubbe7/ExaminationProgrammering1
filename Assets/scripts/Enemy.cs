using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 1;
    public float moveSpeed = 5f;
    public Transform player;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootCooldown = 3f; // Time delay between shots
    private float timeSinceLastShot = 0f;
    public int damageAmount = 1;


    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        // if enemy has less than 1 it get destroy 
        if (hp <= 0)
        {
            GameObject.Destroy(gameObject);

        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            TakeDamage(bullet.damage);
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        MoveUpDownAuto();
        ShootAtPlayer();
    }

    private void MoveUpDownAuto()
    {
        // Your existing code for automatic up and down movement
    }

    private void ShootAtPlayer()
    {
        // Check if enough time has passed since the last shot
        if (Time.time - timeSinceLastShot > shootCooldown)
        {
            // Shoot only if the player and bulletPrefab are set
            if (player != null && bulletPrefab != null)
            {
                // Instantiate the bullet prefab
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                // Adjust bullet properties, like speed and direction, based on your game's design
                bullet.GetComponent<Rigidbody2D>().velocity = (player.position - transform.position).normalized * bulletSpeed;

                // Update the time of the last shot
                timeSinceLastShot = Time.time;
            }
        }
    }


}
