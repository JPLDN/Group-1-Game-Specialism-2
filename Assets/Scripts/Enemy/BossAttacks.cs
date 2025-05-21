using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    public float projectileSpeed = 12f;

    private float shootTimer;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;

        shootTimer = shootInterval;

        if (projectilePrefab == null)
        {
            Debug.LogError("projectile prefab not assigned");
        }

        if (firePoint == null)
        {
            Debug.LogError("firePoint not assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        {
            shootTimer -= Time.deltaTime;
        }
        if (shootTimer <= 0f)
        {
            ShootAtPlayer();
            shootTimer = shootInterval;
        }
    }

    void ShootAtPlayer()
    {
        if (projectilePrefab == null || firePoint == null) return;
        {
            Vector3 direction = (player.position - firePoint.position);
            direction.z = 0f;
            direction = direction.normalized;

            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Debug.Log("Projectile spawned at: " + projectile.transform.position);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * projectileSpeed;
            }
        }
    }
}
