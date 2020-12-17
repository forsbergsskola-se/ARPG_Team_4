using StateMachine;
using UnityEngine;

namespace Interactables {
    public class CrowBarPickUp : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            Debug.Log("trigger");
            if (other.CompareTag("Player")) {
                Debug.Log("player entered");
                other.GetComponent<FSMWorkWithAnimation>().EquipCrowbar();
                Destroy(gameObject);
            }
        }
    }
}
