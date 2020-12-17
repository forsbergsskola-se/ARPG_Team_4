using UnityEngine;

namespace Units.Player {
    /// <summary>
    /// Controls revive mechanism for player. Triggered by ReviveMenuScript through menu buttons.
    /// </summary>

    [RequireComponent(typeof(PlayerMouseInput))]
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerReviveHandler : MonoBehaviour {
        public HealthScriptableObject healthScriptableObject;
        public Transform reviveCheckpointLocation;
        private PlayerHealth _playerHealth;
        private void Start() {
            _playerHealth = GetComponent<PlayerHealth>();
        }
    
        public void ReviveAtLocation() {
            RestoreHealth();
            _playerHealth.TriggerInvulnerability();
            SendMessage("ShowReviveVFX", SendMessageOptions.DontRequireReceiver);
        }

        public void ReviveAtCheckpoint() {
            RestoreHealth();
            _playerHealth.TriggerInvulnerability();
            this.gameObject.transform.position = reviveCheckpointLocation.position;
            SendMessage("ShowReviveVFX", SendMessageOptions.DontRequireReceiver);
        }

        private void RestoreHealth() {
            healthScriptableObject.SetCurrentHealthToMax();
        }
        
    }
}
