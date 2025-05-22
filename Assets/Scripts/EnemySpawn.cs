using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float spawnInterval = 2f;
    public int enemiesToSpawnAtOnce = 3;
    public float spawnDistanceFromCamera = 10f;

    private Camera mainCamera;

    private int totalSpawnedEnemies = 0;  
    public int maxEnemiesToSpawn = 20;    

    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Check if we reached max spawn limit before spawning
            if (totalSpawnedEnemies >= maxEnemiesToSpawn)
            {
                yield break;  // no more spawns
            }

            // Spawn enemies up to the limit but don't exceed maxEnemiesToSpawn
            for (int i = 0; i < enemiesToSpawnAtOnce; i++)
            {
                if (totalSpawnedEnemies >= maxEnemiesToSpawn)
                break;

                SpawnEnemyOffScreen();
                totalSpawnedEnemies++;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void SpawnEnemyOffScreen()
    {
        if (mainCamera.orthographic)
        {
            float screenHeight = mainCamera.orthographicSize * 2;
            float screenWidth = screenHeight * mainCamera.aspect;

            Vector3 cameraPos = mainCamera.transform.position;

            float spawnX = cameraPos.x + (screenWidth / 2) + spawnDistanceFromCamera;
            float spawnY = Random.Range(cameraPos.y - screenHeight / 2, cameraPos.y + screenHeight / 2);

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

            GameObject selectedPrefab = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
            GameObject enemy = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.StartMoving();
            }
        }
    }
}
