using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth = 3;
    public int currentHealth;
    public Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        UpdateHearts(currentHealth);

        if (currentHealth <= 0)
        {
            // Death process here
        }
    }

    public void Heal(int healthObtained)
    {
        if (currentHealth < totalHealth)
        {
            currentHealth += healthObtained;
        }

        UpdateHearts(currentHealth);
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < currentHealth);
        }
    }
}
