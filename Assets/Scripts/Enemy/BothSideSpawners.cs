using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BothSideSpawners : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject bossPrefab;
    public Vector3 bossOnScreenPosition;

    public float spawnInterval = 2f;
    public int enemiesToSpawnAtOnce = 3;
    public float spawnDistanceFromCamera = 10f;
    public int maxEnemiesInScene = 20; // Max Enemy Count

    public int killsToSpawnBoss = 19;

    private Camera mainCamera;
    private int currentEnemyCount = 0; // Tracking the number of enemies
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
            Debug.Log($"KillCount = {killCount}, killsToSpawnBoss = {killsToSpawnBoss}");
            // Only spawn if the number of enemies in the scene is less than the maximum allowed
            if (!bossSpawned && currentEnemyCount < maxEnemiesInScene)
            {
                for (int i = 0; i < enemiesToSpawnAtOnce; i++)
                {
                    SpawnEnemyOffScreen();
                }
            }

            if (!bossSpawned && killCount >= killsToSpawnBoss)
            {
                SpawnBoss();
                bossSpawned = true;
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

            // Randomised Spawn between left and right side of screen
            int side = Random.value > 0.5f ? 1 : -1; 

            // Spawn on X side, how far away they spawn on both sides
            float spawnX = cameraPos.x + (screenWidth / 2) * side + spawnDistanceFromCamera * side;

            // Spawn on Y side, randomised spawn but within screen boundaries
            float spawnY = Random.Range(cameraPos.y - screenHeight / 2, cameraPos.y + screenHeight / 2);

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

            // Spawn the Enemies
            GameObject selectedPrefab = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
            GameObject enemy = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

            EnemyDeathNotifier notifier = enemy.AddComponent<EnemyDeathNotifier>();
            notifier.SetSpawner(this);

            // Increase the enemy count
            currentEnemyCount++;

            // Optionally start the enemy movement if you have an EnemyMovement script
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.StartMoving();
            }

            
            Destroy(enemy, 13f); 
        }
    }

    // ecrease the current enemy count when an enemy is destroyed
    public void OnEnemyDestroyed()
    {
        currentEnemyCount--;
        killCount++;
        Debug.Log($"Enemy killed, kill count is now {killCount}");
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
}
