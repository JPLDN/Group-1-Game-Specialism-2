using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject autoSelectPause;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggles the pause menu with Escape
            if (gamePaused)
            {
                Resume();
            }
            // Only pauses if the player is still alive
            else if (!gamePaused && Time.timeScale != 0f)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Resumes the game
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void Pause()
    {
        // Pauses the game and automatically selects Resume button
        EventSystem.current.SetSelectedGameObject(autoSelectPause);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void Menu()
    {
        // Returns the player to the main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
