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
        private PlayerHealth _playerHealth = null;
        //private PlayerMovement _playerMovementRef = null;
        private PlayerMouseInput _playerMouseInputRef = null;
        private void Start() {
            _playerHealth = GetComponent<PlayerHealth>();
            _playerMouseInputRef = GetComponent<PlayerMouseInput>();
        }
    
        public void ReviveAtLocation() {
            RestoreHealthAndEnableControls();
            _playerHealth.TriggerInvulnerability();
        }

        public void ReviveAtCheckpoint() {
            RestoreHealthAndEnableControls();
            this.gameObject.transform.position = reviveCheckpointLocation.position;
        }

        private void RestoreHealthAndEnableControls() {
            healthScriptableObject.SetCurrentHealthToMax();
            _playerMouseInputRef.InputDisabled = false;
        }
    }
}
