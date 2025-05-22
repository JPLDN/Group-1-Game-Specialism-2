using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public EnemySpawn enemySpawner;

    private void OnTriggerEnter2D(Collider2D other2D)
    {
        if (other2D.CompareTag("Player"))
        {
            return;
        }

        if (other2D.CompareTag("Enemy"))
        {
            Destroy(other2D.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }

        if (other.CompareTag("Enemy"))
        {
            if (enemySpawner != null)
            {
                Debug.Log("Calling RegisterKill from bullet");
                enemySpawner.RegisterKill();
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("Boss"))
        {
            BossHealth boss = other.GetComponent<BossHealth>();
            if (boss != null)
            {
                boss.TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
