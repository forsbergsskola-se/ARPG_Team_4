using System;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour {
    public Transform teleportTarget;
    public bool isEnabled;

    void Start() {
        isEnabled = false;
    }

    private void Update() {
        if (isEnabled) {
            // Activate Particle Effect or Animation
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!isEnabled)
            return;
        if (other.CompareTag("Player")) {
            other.GetComponentInParent<Transform>().position = teleportTarget.position;
            other.GetComponentInParent<NavMeshAgent>().SetDestination(teleportTarget.position);
        }
    }

}
