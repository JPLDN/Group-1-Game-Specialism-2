using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BothSideSpawners : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int enemiesToSpawnAtOnce = 3;
    public float spawnDistanceFromCamera = 10f;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnEnemies());
    }
    
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for (int i = 0; i < enemiesToSpawnAtOnce; i++)
            {
                SpawnEnemyOffScreen();
            }
        }

        yield return new WaitForSeconds(spawnInterval);
    }

    void SpawnEnemyOffScreen()
    {
        if (mainCamera.orthographic)
        {
            float screenHeight = mainCamera.orthographicSize * 2;
            float screenWidth = screenHeight * mainCamera.aspect;

            Vector3 cameraPos = mainCamera.transform.position;

            // Randomised spawn between left and right side
            int side = Random.value > 0.5f ? 1 : -1;

            // Spawn Position on X side, how far they spawn from left or right side of screen
            float spawnX = cameraPos.x + (screenWidth / 2) * side + spawnDistanceFromCamera;

            // Spawn Position on Y side, random placement of the spawn that's within the screen bounds
            float spawnY = Random.Range(cameraPos.y - screenHeight / 2, cameraPos.y + screenHeight / 2);

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.StartMoving();
            }
        }
    }
}
