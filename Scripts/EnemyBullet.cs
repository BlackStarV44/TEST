using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBullet : MonoBehaviour
{
    private float enemyBulletSp = 10f;
    private Vector2 enemyBulletPosition;
    





    private void Update()
    {
        enemyBulletPosition = transform.position;
        enemyBulletPosition.y -= enemyBulletSp * Time.deltaTime;
        transform.position = enemyBulletPosition;

        DestroyEnemyBullet();
    }
    

    
    void DestroyEnemyBullet()
    {
        if (enemyBulletPosition.y <= -7)
        {

            Destroy(gameObject);
        
        }
    }

}
