using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Units.Player {
    public class PlayerHealth : MonoBehaviour, IDamagable {
        public HealthScriptableObject healthScriptableObject;
        public UnityEvent GetDamaged;
        [Tooltip("the duration the player is invulnerable from damage on revival")]
        [SerializeField] private float _invulnerabilityDuration = 5f;
        private bool _invulnerable = false;
    
        public void TakeDamage(int damage) {
            
            //Player can be invulnerable to damage
            if (_invulnerable)
                return;
            
            healthScriptableObject.CurrentHealth -= damage;
            GetDamaged.Invoke();
        }
        
        public void GainHealth(int healValue) {
            healthScriptableObject.CurrentHealth += healValue;
            // GetDamaged.Invoke();
        }

        public void TriggerInvulnerability() {
            _invulnerable = true;
            Debug.Log("Player invulnerable: " + _invulnerable);
            StartCoroutine(InvulnerabilityTimer());
        }

        // Deactivates invulnerable after duration.
        private IEnumerator InvulnerabilityTimer() {
            yield return new WaitForSeconds(_invulnerabilityDuration);
            _invulnerable = false;
            Debug.Log("Player invulnerable: " + _invulnerable);
        }
    }
}
