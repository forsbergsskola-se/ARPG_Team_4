using System;
using UnityEngine;
public class DetectionTrigger : MonoBehaviour {
    private PatrolThreat _patrolThreat;

    private void Start() {
        _patrolThreat = GetComponentInParent<PatrolThreat>();
        if (_patrolThreat == null)
            Debug.LogWarning("Patrol threat not found", this);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Detection trigger");
        if (other.tag == "Player") {
            Debug.Log("Player detected");
            _patrolThreat.PlayerDetected = true;
        }
    }
    
    private void OnTriggerExit(Collider other) {
        Debug.Log("Detection trigger");
        if (other.CompareTag("Player")) {
            Debug.Log("Player left detection sphere");
            _patrolThreat.PlayerDetected = false;
        }
    }
}
