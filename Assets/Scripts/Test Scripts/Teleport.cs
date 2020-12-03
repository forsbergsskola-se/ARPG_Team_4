using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour {
    public Transform teleportTarget;
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Entered Portal");

        other.GetComponent<NavMeshAgent>().enabled = false;
        other.transform.position = teleportTarget.position;
        other.GetComponent<NavMeshAgent>().enabled = true;
    }

}
