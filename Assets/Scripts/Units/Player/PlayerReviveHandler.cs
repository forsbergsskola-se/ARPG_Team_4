using Units.Player;
using UnityEngine;
/// <summary>
/// Controls revive mechanism for player. Triggered by ReviveMenuScript through menu buttons.
/// </summary>

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerReviveHandler : MonoBehaviour {
    public HealthScriptableObject healthScriptableObject;
    public Transform reviveCheckpointLocation;
    private PlayerHealth _playerHealth = null;
    private PlayerMovement _playerMovementRef = null;
    private void Start() {
        // Get references
        _playerHealth = GetComponent<PlayerHealth>();
        _playerMovementRef = GetComponent<PlayerMovement>();
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
        _playerMovementRef.InputDisabled = false;
    }
}
