using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject[] menuPanels;

    // Start is called before the first frame update

    void Start()
    {
        // Shows first panel on start
        ShowPanel(0);
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
