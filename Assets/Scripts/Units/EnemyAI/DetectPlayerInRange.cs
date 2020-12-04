using UnityEngine;

// WORK IN PROGRESS. BELONGS TO TRACKING THREAT
namespace Units.EnemyAI {
    public class DetectPlayerInRange : MonoBehaviour {
        private WaypointMovement waypointMovement;

        private void Start() {
            waypointMovement = GetComponentInParent<WaypointMovement>();
            if (waypointMovement == null)
                Debug.LogWarning("Patrol threat not found", this);
        }

        private void OnTriggerEnter(Collider other) {
            Debug.Log("Detection trigger");
            if (other.tag == "Player") {
                Debug.Log("Player detected");
                //waypointMovement.PlayerDetected = true;
            }
        }
    
        private void OnTriggerExit(Collider other) {
            Debug.Log("Detection trigger");
            if (other.CompareTag("Player")) {
                Debug.Log("Player left detection sphere");
                //waypointMovement.PlayerDetected = false;
            }
        }
    }
}
