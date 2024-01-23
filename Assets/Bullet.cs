using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public int damage = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ShootBullet(Vector2 direction, float speed)
    {
        rb.velocity = direction * speed;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemyComp = collision.gameObject.GetComponent<Enemy>();
        if (enemyComp != null)
        {
            enemyComp.TakeDamage(1);
            GameObject.Destroy(gameObject);

        }
    }
}
