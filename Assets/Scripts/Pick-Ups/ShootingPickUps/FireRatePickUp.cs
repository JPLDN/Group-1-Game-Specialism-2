using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePickUp : MonoBehaviour
{
    public float duration = 15f;
    public float fireRateMultiplier = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShoot playerShoot = other.GetComponent<PlayerShoot>();
            if (playerShoot != null)
            {
                playerShoot.StartFireRateBoost(duration, fireRateMultiplier);
            }
            Destroy(gameObject);
        }
    }
}
