using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShieldPickups : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Heals player or activates shield based on object tag
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthItem"))
        {
            Destroy(other.gameObject);
            playerHealth.Heal(1);
        }
        else if (other.CompareTag("ShieldItem"))
        {
            Destroy(other.gameObject);
            playerHealth.ActivateShield();
        }
    }
}
