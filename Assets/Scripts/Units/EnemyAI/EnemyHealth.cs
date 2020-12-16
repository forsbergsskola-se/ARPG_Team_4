using UnityEngine;

namespace Units.EnemyAI {
    public class EnemyHealth : MonoBehaviour, IDamagable {
        [SerializeField] private int maxHealth = 10;
        private int _currentHealth;

        public void TakeDamage(int damage) {
            // Clamp ensures current health is always between 0 and max health
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, maxHealth);
            SendMessage("ShowAlienBloodVFX", SendMessageOptions.DontRequireReceiver);
            // If health is 0, enemy dies
            if (_currentHealth == 0) {
                // Debug.Log($"{gameObject.name} has died!");
                Destroy(gameObject);
            }
        
            // Placeholder Debug.Log to display enemy HP
            Debug.Log($"{name} : {_currentHealth}/{maxHealth} Health : {damage} damage taken");
        }
        public void GainHealth(int healValue) {
            Debug.Log($"{name} : {_currentHealth}/{maxHealth} Health : {healValue} gained?");
        }
        private void Awake() {
            _currentHealth = maxHealth;
        }
    }
}
