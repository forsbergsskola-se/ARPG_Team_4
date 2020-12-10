using Units;
using Units.Player;
using UnityEngine;

namespace Interactables {
    public class HealthPickUp : MonoBehaviour {
        private PlayerHealth playerHealth;
        public int healValue = -10;

        private void Start() {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                other.GetComponent<IDamagable>().GainHealth(healValue);
                Destroy(gameObject);
            }
        }
    }
}