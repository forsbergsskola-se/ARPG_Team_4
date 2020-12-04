using Units.Player;
using UnityEngine;
using UnityEngine.UI;

namespace GUI {
    /// <summary>
    /// Shows the player health.
    /// Registers for health updates on Start()
    /// </summary>
    [RequireComponent(typeof(Slider))]
    public class HealthBarScript : MonoBehaviour {
        public HealthScriptableObject healthScriptableObject;
        private Slider _healthBar;
        private void Start() {
            _healthBar = GetComponent<Slider>();
        
            // Set initial value
            _healthBar.maxValue = healthScriptableObject.MaxHealth;
            UpdateHealthBar(healthScriptableObject.CurrentHealth);

            // Register for health updates
            healthScriptableObject.OnHealthChange += UpdateHealthBar;
        }

        /// <summary>
        /// Updates the health bar. Currently set to listen to healthScriptableObject.
        /// </summary>
        /// <param name="newHealthVal"> The new health value to set the bar to </param>
        private void UpdateHealthBar(int newHealthVal) {
            _healthBar.value = newHealthVal;
        }
    }
}
