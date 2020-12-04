using UnityEngine;
using UnityEngine.Events;

namespace Units.Player {
    [CreateAssetMenu]
    public class HealthScriptableObject : ScriptableObject {
   
        [SerializeField] private int _currentHealth = 10;
        [SerializeField] private int _maxHealth = 10;
    
        public UnityAction OnDeath;
        public UnityAction<int> OnHealthChange;
    
        public int CurrentHealth {
            get => _currentHealth;
            set {
                // if player dies
                if (value < 0) {
                    _currentHealth = 0;
                    OnDeath();
                }
                // if player gets more than max health
                else if (value > _maxHealth)
                    _currentHealth = _maxHealth;
                _currentHealth = value;
            
                // Notify listeners
                OnHealthChange(CurrentHealth);
            }
        }
    
        public int MaxHealth {
            get => _maxHealth;
            private set => _maxHealth = value;
        }
    
        // TODO save playerprefs
    }
}
