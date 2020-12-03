using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour {
    public int MaxHealth = 30;
    public float Health = 30;
    public int HealthModifier = 1;
    public Dictionary<string, float[]> InvokeEffect = new Dictionary<string, float[]>();
    public delegate void MultiDelegate();
    public MultiDelegate effectDelegate;

    public void Update() {
        Invoke("ApplyBurnEffect", 0);
    }
    
    public void UpdateHealth(float damage) {
        Health = Mathf.Min(Health, MaxHealth);
        Health = Mathf.Max(Health - (damage * Time.deltaTime), 0);
        Debug.Log("Health: " + Health);

        if (Health == 0) {
            Debug.Log("Enemy/Player Died");
        }
    }

    public MultiDelegate ApplyBurnEffect(float burnDamage, float timer) {
        //if (hitbox == null) return null;
        Debug.Log("got applyburn");
        Debug.Log("Timer" + timer);
        timer -= Time.deltaTime;
        UpdateHealth(burnDamage);
        //if (timer <= 0.0f) effectDelegate -= ApplyBurnEffect(burnDamage, timer, hitbox);
        return null;
    }
}
