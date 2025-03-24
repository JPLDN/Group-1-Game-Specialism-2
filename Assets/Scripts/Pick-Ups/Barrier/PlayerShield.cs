using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private bool isShieldActive = false;
    
    public void ActivateShield()
    {
        if (!isShieldActive)
        {
            isShieldActive = true;
            Debug.Log("Shield Active");
        }
    }

    public void DeactivateShield()
    {
        isShieldActive = false;
        Debug.Log("Shield Deactivated");
    }

    public void OnPlayerHit()
    {
        if (isShieldActive)
        {
            DeactivateShield();
        }
    }
}
