using UnityEngine;
using UnityEngine.Events;

namespace Units.Player {
    public class PlayerHealth : MonoBehaviour, IDamagable {
        public HealthScriptableObject healthScriptableObject;
        public UnityEvent GetDamaged;
    
        public void TakeDamage(int damage) {
            healthScriptableObject.CurrentHealth -= damage;
            GetDamaged.Invoke();
        }
    }
}
