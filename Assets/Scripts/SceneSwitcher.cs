using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Stores the current scene's index value
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void SwitchScene()
    {
        // Switches to the next scene in the index
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
