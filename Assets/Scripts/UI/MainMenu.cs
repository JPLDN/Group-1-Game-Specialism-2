using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject arcadePanel;

    // Loads first cutscene
    public void StartButton()
    {
        SceneManager.LoadScene(2);
    }

    // Displays panel explaining the lack of arcade mode
    public void ArcadeButton()
    {
        arcadePanel.SetActive(true);
        Invoke("HideArcadePanel", 4.0f);
    }

    // Hides the panel after being invoked
    public void HideArcadePanel()
    {
        arcadePanel.SetActive(false);
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
