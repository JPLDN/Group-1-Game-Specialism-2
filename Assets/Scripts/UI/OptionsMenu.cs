using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour, ISelectHandler
{
    public GameObject[] menuPanels;

    // Start is called before the first frame update
    void Start()
    {
        // Shows first panel on start
        ShowPanel(0);
    }

    void Update()
    {
        // Returns to main menu if escape is pressed
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        // Activates the OnClick() event when selected
        GetComponent<Button>().onClick.Invoke();
    }

    public void ShowPanel(int panelIndex)
    {
        // Cycles through each panel
        for (int i = 0; i < menuPanels.Length; i++)
        {
            // Sets active panels to true and inactive panels to false
            menuPanels[i].SetActive(i == panelIndex);
        }
    }
}
