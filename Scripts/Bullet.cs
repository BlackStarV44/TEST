using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifetime = 2.0f; 

    private Rigidbody2D rb;
    private float timer = 0.0f;
    [SerializeField] GameObject explosionPre;
    private Vector2 collisionPoint;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = Vector2.up * speed;
        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collisionPoint = transform.position;
            Destroy(collision.gameObject);
            Instantiate(explosionPre, collisionPoint, Quaternion.identity);

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UpdateScore();
        }
        if (collision.gameObject.CompareTag("EnemyAtk"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
}

