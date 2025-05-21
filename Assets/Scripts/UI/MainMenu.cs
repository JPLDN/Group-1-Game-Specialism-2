using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject arcadePanel;
    public AudioSource uiSelect;

    // Loads first cutscene
    public void StartButton()
    {
        uiSelect.Play();
        SceneManager.LoadScene(2);
    }

    // Displays panel explaining the lack of arcade mode
    public void ArcadeButton()
    {
        uiSelect.Play();
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
        uiSelect.Play();
        SceneManager.LoadScene(1);
    }

    // Closes application and logs
    public void QuitButton()
    {
        uiSelect.Play();
        Debug.Log("Quit");
        Application.Quit();
    }
}
