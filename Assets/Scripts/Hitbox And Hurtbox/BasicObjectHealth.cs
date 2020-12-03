using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObjectHealth : MonoBehaviour
{
    public int MaxHealth = 30;
    public float Health = 30;
    public int HealthModifier = 1;

    public void UpdateHealth(float damage) {
        
        Health = Mathf.Min(Health, MaxHealth);
        Health = Mathf.Max(Health - damage, 0);
        Debug.Log("Health: " + Health);

        if (Health == 0) Debug.Log("Enemy/Player Died");
    }
}
