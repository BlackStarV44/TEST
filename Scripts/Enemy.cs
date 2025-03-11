using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2.0f;

    
    private Vector2 enemyPosition;

    [SerializeField] GameObject enemyBulletPre;
    [SerializeField] Transform enemyBulletSpawn; 

    void Start()
    {
       
        StartCoroutine(ShootNextBullet());
    }

    void Update()
    {
        enemyPosition = transform.position;
        enemyPosition.y -= speed * Time.deltaTime;
        transform.position = enemyPosition;
        DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        if (enemyPosition.y <=-8)
        {
            Destroy(gameObject);
        }
        
    }
     private void ShootBullet()
    {
        Instantiate(enemyBulletPre, enemyBulletSpawn.transform.position, Quaternion.identity);
        StartCoroutine(ShootNextBullet());
    }
    IEnumerator ShootNextBullet()
    {
        yield return new WaitForSeconds(1);
        ShootBullet();
    }


}

