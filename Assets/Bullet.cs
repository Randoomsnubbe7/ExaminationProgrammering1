using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ShootBullet(Vector2 direction, float speed)
    {
        rb.velocity = direction * speed;
    }
}
