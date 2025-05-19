using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShotPickUp : MonoBehaviour
{
    public float spreadShotDuration = 20f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShoot playerShoot = other.GetComponent<PlayerShoot>();
            if (playerShoot != null)
            {
                Debug.Log("SpreadShot pickup triggered");
                playerShoot.EnableSpreadShot(spreadShotDuration);
            }
            Destroy(gameObject);
        }
    }
}
