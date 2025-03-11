using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float speed = 5.0f;
    public float fireRate = 10.0f;
    public GameObject bulletPrefab;
    private Vector2 playerPosition;
    private float nextFire = 0.0f;
    private Rigidbody2D rb;
    public TextMeshProUGUI playerScoreText;
    private int playerScore = 0;
    public GameObject gameOverScreen;
    public GameObject explosionPre;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        rb.linearVelocity = movement * speed;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1.0f / fireRate;
            Shoot();
        }

        DisplayScore();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyAtk"))
        {
            Destroy(gameObject);
            Instantiate(explosionPre, playerPosition, Quaternion.identity);
            gameOverScreen.SetActive(true);
        }
    }

    private void DisplayScore()
    {
        playerScoreText.text = "Scores " + playerScore.ToString();
    }

    public void UpdateScore()
    {
        playerScore += 20;
        LvlManager.instance.UpdateScore(playerScore);
    }

    public void UpdateScoreText()
    {
        playerScoreText.text = "Scores " + playerScore.ToString();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * 10.0f;
    }
}








