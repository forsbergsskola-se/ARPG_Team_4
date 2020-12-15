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
        //private PlayerMovement _playerMovementRef = null;
        private PlayerMouseInput _playerMouseInputRef;
        private void Start() {
            _playerHealth = GetComponent<PlayerHealth>();
            _playerMouseInputRef = GetComponent<PlayerMouseInput>();
        }
    
        public void ReviveAtLocation() {
            RestoreHealthAndEnableControls();
            _playerHealth.TriggerInvulnerability();
            SendMessage("ShowReviveVFX", SendMessageOptions.DontRequireReceiver);
        }

        public void ReviveAtCheckpoint() {
            RestoreHealthAndEnableControls();
            _playerHealth.TriggerInvulnerability();
            this.gameObject.transform.position = reviveCheckpointLocation.position;
            SendMessage("ShowReviveVFX", SendMessageOptions.DontRequireReceiver);
        }

        private void RestoreHealthAndEnableControls() {
            healthScriptableObject.SetCurrentHealthToMax();
            _playerMouseInputRef.InputDisabled = false;
        }
    }
}
