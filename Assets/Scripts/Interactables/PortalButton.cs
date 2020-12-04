using UnityEngine;

namespace Interactables {
    public class PortalButton : MonoBehaviour {
        public GameObject[] portalsToActivate;
        public bool insideCollider;
        public GameObject interactText;

        private void Start() {
            interactText.SetActive(false);
            foreach (GameObject go in portalsToActivate) {
                go.GetComponent<ParticleSystem>().Stop();
            }
        }

        private void Update() {
            if (insideCollider) {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    Debug.Log("Pressed Space");
                    interactText.SetActive(false);
                    foreach (GameObject go in portalsToActivate) {
                        go.GetComponent<Portal>().isEnabled = true;
                        go.GetComponent<ParticleSystem>().Play();
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other) {
            insideCollider = true;
            interactText.SetActive(true);
        }

        private void OnTriggerExit(Collider other) {
            insideCollider = false;
            interactText.SetActive(false);
        }
    }
}
