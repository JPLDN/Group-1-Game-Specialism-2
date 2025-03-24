using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShotPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShoot playerShoot = other.GetComponent<PlayerShoot>();
            if (playerShoot != null)
            {
                Debug.Log("SpreadShot pickup triggered");
                playerShoot.EnableSpreadShot();
            }
            Destroy(gameObject);
        }
    }
}
