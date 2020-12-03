using UnityEngine;

public class ObjectHealth : MonoBehaviour {
    public int MaxHealth = 30;
    public float Health = 30;
    public int HealthModifier = 1;

    public void UpdateHealth(float damage) {
        Health = Mathf.Min(Health, MaxHealth);
        Health = Mathf.Max(Health - (damage * Time.deltaTime), 0);
        Debug.Log("Health: " + Health);

        if (Health == 0) {
            Debug.Log("Enemy/Player Died");
        }
    }
    public void ApplyBurn(float burnDamage, float timer, GameObject hitbox) {
        timer -= Time.deltaTime;
        UpdateHealth(burnDamage);
        //if (timer <= 0.0f) hitbox.SetActive(false);
    }
}
