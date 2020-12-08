using Units;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable {
    public int maxHealth = 10;
    private int _currentHealth;

    public void TakeDamage(int damage) {
        // Clamp ensures current health is always between 0 and max health
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, maxHealth);
        
        // If health is 0, enemy dies
        if (_currentHealth == 0) {
            Debug.Log($"{gameObject.name} has died!");
            Destroy(gameObject);
        }
        
        // Placeholder Debug.Log to display enemy HP
        Debug.Log($"{name} : {_currentHealth}/{maxHealth} Health : took {damage} damage");
    }
    private void Awake() {
        _currentHealth = maxHealth;
    }
}
