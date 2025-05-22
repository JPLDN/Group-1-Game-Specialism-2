using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject bossPrefab;  
    public float spawnInterval = 2f;
    public int enemiesToSpawnAtOnce = 3;
    public float spawnDistanceFromCamera = 10f;
    public Vector3 bossOnScreenPosition;  

    private Camera mainCamera;

    private int totalSpawnedEnemies = 0;  
    public int maxEnemiesToSpawn = 20;    

    public int killsToSpawnBoss = 20;  

    private int killCount = 0;  
    private bool bossSpawned = false;  

    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Spawn boss if killCount reached and boss not spawned yet
            if (!bossSpawned && killCount >= killsToSpawnBoss)
            {
                SpawnBoss();
                bossSpawned = true;
            }
            else
            {
                // Check if we reached max spawn limit before spawning regular enemies
                if (totalSpawnedEnemies < maxEnemiesToSpawn)
                {
                    // Spawn enemies up to the limit but don't exceed maxEnemiesToSpawn
                    for (int i = 0; i < enemiesToSpawnAtOnce; i++)
                    {
                        if (totalSpawnedEnemies >= maxEnemiesToSpawn)
                            break;

                        SpawnEnemyOffScreen();
                        totalSpawnedEnemies++;
                    }
                }
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

    void SpawnBoss()
    {
        if (bossPrefab == null)
        {
            Debug.LogWarning("Boss prefab not assigned");
            return;
        }

        GameObject boss = Instantiate(bossPrefab, Vector3.zero, Quaternion.identity);

        BossMovement bossMovement = boss.GetComponent<BossMovement>();
        if (bossMovement != null)
        {
            bossMovement.onScreenPosition = bossOnScreenPosition;
        }
        else
        {
            Debug.Log("Boss prefab missing movement script");
        }
    }

    public void RegisterKill()
    {
        killCount++;
        Debug.Log($"Kill count is now: {killCount}");
    }
}