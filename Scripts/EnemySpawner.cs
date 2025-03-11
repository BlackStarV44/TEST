using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefabs;
    private float spawnY = 5;
    private float minSpawnX = -5;
    private float maxspawnX = 5;
    private float spawnX;
    private Vector2 spawnPosition;
    private float minSpawnDelay = 2;
    private float maxSpawnDelay = 3;
    private float spawnDelay;




    private void Start()
    {
        StartCoroutine(SpawnEnemyRandom());
    }



    private void SpawnEnemy()
    {
        spawnX = Random.Range(minSpawnX, maxspawnX);
        spawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(enemyPrefabs, spawnPosition, Quaternion.identity);
        StartCoroutine(SpawnEnemyRandom());
    }


    IEnumerator SpawnEnemyRandom()
    {
        spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        yield return new WaitForSeconds(spawnDelay);
        SpawnEnemy();
    }
}
