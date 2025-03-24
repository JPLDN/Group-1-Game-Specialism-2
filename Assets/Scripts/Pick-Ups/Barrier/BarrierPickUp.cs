using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPickUp : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShield playerShield = other.GetComponent<PlayerShield>();
            if (playerShield != null)
            {
                playerShield.ActivateShield();
                Destroy(gameObject);
            }
        }
    }
}
