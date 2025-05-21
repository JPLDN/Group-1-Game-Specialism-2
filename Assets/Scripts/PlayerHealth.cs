using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth = 3;
    public int currentHealth;
    public bool shieldStatus;
    public Image[] heartsUI;
    public Image shieldUI;
    public GameObject deathScreen;
    public GameObject autoSelectDeath;

    public AudioSource healthPickup;
    public AudioSource playerHit;
    public AudioSource shieldBreak;
    public AudioSource playerDeath;
    public AudioSource powerUpPickup;

    // Start is called before the first frame update
    void Start()
    {
        // Each level starts with full health and no shield
        currentHealth = totalHealth;
        shieldStatus = false;
    }

    // Player takes damage when called with an integer
    public void TakeDamage(int damageTaken)
    {
        if (shieldStatus == false)
        {
            // Reduces health if shield is down
            playerHit.Play();
            currentHealth -= damageTaken;
            UpdateHealth(currentHealth);
        }
        else
        {
            // Disables shield
            shieldBreak.Play();
            shieldStatus = false;
            UpdateHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            // Enables death screen when health hits 0
            playerDeath.Play();
            Time.timeScale = 0;
            deathScreen.SetActive(true);
            // Automatically selects Restart button for keyboard controls
            EventSystem.current.SetSelectedGameObject(autoSelectDeath);
        }
    }

    public void Heal(int healthObtained)
    {
        if (currentHealth < totalHealth)
        {
            // Heals player if health isn't at its max value
            healthPickup.Play();
            currentHealth += healthObtained;
        }

        UpdateHealth(currentHealth);
    }

    public void ActivateShield()
    {
        // Enables the shield power-up
        powerUpPickup.Play();
        shieldStatus = true;
        UpdateHealth(currentHealth);
    }

    public void UpdateHealth(int currentHealth)
    {
        // Changes the hearts in the UI to match the player's health
        for (int i = 0; i < heartsUI.Length; i++)
        {
            heartsUI[i].enabled = (i < currentHealth);
        }

        // Enables or disables the shield in the UI
        if (shieldStatus == true)
        {
            shieldUI.enabled = true;
        }
        else
        {
            shieldUI.enabled = false;
        }
    }
}
