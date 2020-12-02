using UnityEngine;

public class ObjectHealth : MonoBehaviour {
    public int MaxHealth = 30;
    public int Health = 30;
    public int HealthModifier = 1;

    public void UpdateHealth(int damage) {
        Health = Mathf.Min(Health, MaxHealth);
        Health = Mathf.Max(Health - damage * HealthModifier, 0);
        Debug.Log("Health: " + Health);
        
        if (Health == 0) { 
            Debug.Log("Enemy/Player Died");
        }
    }
}
