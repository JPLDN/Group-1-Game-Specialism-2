using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int totalHealth;
    public int currentHealth;
    private SceneSwitcher sceneSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        totalHealth = currentHealth;
        sceneSwitcher = GetComponent<SceneSwitcher>();
    }
    
    // Boss takes damage when attacked by player
    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;

        // Kills boss when health reaches 0
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Invoke("EndFight", 5.0f);
        }
    }

    // Attach SceneSwitcher.cs to same GameObject
    // Switches to the next scene in the index
    void EndFight()
    {
        sceneSwitcher.SwitchScene();
    }
}
