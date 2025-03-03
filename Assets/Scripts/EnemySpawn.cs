using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int enemiesToSpawnAtOnce = 3;

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

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemyOffScreen()
    {
        if (mainCamera.orthographic)
        {
            float screenHeight = mainCamera.orthographicSize * 2;
            float screenWidth = screenHeight * mainCamera.aspect;

            Vector3 offScreenPosition = new Vector3(Random.Range(-screenWidth - 5f, screenWidth + 5f), Random.Range(-screenHeight - 5f, screenHeight + 5f), 0f);

            GameObject enemy = Instantiate(enemyPrefab, offScreenPosition, Quaternion.identity);

            enemy.GetComponent<EnemyMovement>().StartMoving();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
