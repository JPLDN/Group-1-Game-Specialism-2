using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth = 3;
    public int currentHealth;
    public bool shieldStatus = false;
    public Image[] hearts;
    public Image shield;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        if (shieldStatus == false)
        {
            currentHealth -= damageTaken;
            UpdateHealth(currentHealth);
        }
        else
        {
            shieldStatus = false;
            UpdateHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
        }
    }

    public void Heal(int healthObtained)
    {
        if (currentHealth < totalHealth)
        {
            currentHealth += healthObtained;
        }

        UpdateHealth(currentHealth);
    }

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < currentHealth);
        }

        if (shieldStatus == true)
        {
            shield.enabled = true;
        }
        else
        {
            shield.enabled = false;
        }
    }
}
