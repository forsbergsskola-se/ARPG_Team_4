using Units;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable {
    public int maxHealth = 10;
    private int _currentHealth;

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        
        //If health is 0 or lower, health is set to 0 and game object is destroyed
        if (_currentHealth <= 0) {
            _currentHealth = 0;
            Destroy(gameObject);
        }
        Debug.Log($"{name} : {_currentHealth}/{maxHealth} Health : took {damage} damage");
    }
    private void Awake() {
        _currentHealth = maxHealth;
    }
}
