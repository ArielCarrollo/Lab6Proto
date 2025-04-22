using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public bool isCovering = false;
    public Action<float> onTakeDamage;
    public Action<bool> onCoverChanged; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cover();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Uncover();
        }
    }

    public void TakeDamage(float amount)
    {
        if (onTakeDamage != null)
        {
            onTakeDamage(amount);
        }
        Debug.Log("Health: " + health);
    }

    public void Cover()
    {
        isCovering = true;
        Debug.Log("Player is covering!");
        if (onCoverChanged != null)
        {
            onCoverChanged(true);  
        }
    }

    public void Uncover()
    {
        isCovering = false;
        Debug.Log("Player stopped covering.");
        if (onCoverChanged != null) 
        {
            onCoverChanged(false);  
        }
    }
}


