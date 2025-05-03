using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Loads first cutscene
    public void StartButton()
    {
        SceneManager.LoadScene(2);
    }

    // Loads settings menu scene
    public void SettingsButton()
    {
        SceneManager.LoadScene(1);
    }

    // Closes application and logs
    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
