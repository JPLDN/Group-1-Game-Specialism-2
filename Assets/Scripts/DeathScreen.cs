using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void Restart()
    {
        // Reloads the scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        // Returns player to the main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
