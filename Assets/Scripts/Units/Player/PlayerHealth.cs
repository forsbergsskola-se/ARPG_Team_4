using UnityEngine;

namespace Units.Player {
    public class PlayerHealth : MonoBehaviour, IDamagable {
        public HealthScriptableObject healthScriptableObject;
    
        public void TakeDamage(int damage) {
            healthScriptableObject.CurrentHealth -= damage;
        }
    }
}
