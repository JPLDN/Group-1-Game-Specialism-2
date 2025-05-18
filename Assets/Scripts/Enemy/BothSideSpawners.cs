using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BothSideSpawners : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int enemiesToSpawnAtOnce = 3;
    public float spawnDistanceFromCamera = 10f;
    public int maxEnemiesInScene = 20; // Max Enemy Count

    private Camera mainCamera;
    private int currentEnemyCount = 0; // Tracking the number of enemies

    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Only spawn if the number of enemies in the scene is less than the maximum allowed
            if (currentEnemyCount < maxEnemiesInScene)
            {
                for (int i = 0; i < enemiesToSpawnAtOnce; i++)
                {
                    SpawnEnemyOffScreen();
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

            // Randomised Spawn between left and right side of screen
            int side = Random.value > 0.5f ? 1 : -1; 

            // Spawn on X side, how far away they spawn on both sides
            float spawnX = cameraPos.x + (screenWidth / 2) * side + spawnDistanceFromCamera * side;

            // Spawn on Y side, randomised spawn but within screen boundaries
            float spawnY = Random.Range(cameraPos.y - screenHeight / 2, cameraPos.y + screenHeight / 2);

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

            // Spawn the Enemies
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Increase the enemy count
            currentEnemyCount++;

            // Optionally start the enemy movement if you have an EnemyMovement script
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.StartMoving();
            }

            // Destroy the enemy when it goes off-screen (Optional)
            // You can add this to prevent the scene from filling up with enemies:
            // Destroy(enemy, 10f); // Destroys the enemy after 10 seconds (adjust as needed)
        }
    }

    // ecrease the current enemy count when an enemy is destroyed
    public void OnEnemyDestroyed()
    {
        currentEnemyCount--;
    }
}
