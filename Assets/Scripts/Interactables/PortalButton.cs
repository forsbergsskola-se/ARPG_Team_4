using UnityEngine;

namespace Interactables {
    public class PortalButton : MonoBehaviour {
        public bool insideCollider;
        public GameObject interactText;
        public GameObject lightGameObject;
        public Material newLight;
        public GameObject doorToUnlock;

        private void Start() {
            interactText.SetActive(false);
        }

        private void Update() {
            if (insideCollider) {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    lightGameObject.GetComponent<MeshRenderer>().material = newLight;
                    doorToUnlock.GetComponent<Open_And_Close>().enabled = true;
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