using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
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
