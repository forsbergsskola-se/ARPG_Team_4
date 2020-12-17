using UnityEngine;

namespace Interactables {
    public class PortalButton : MonoBehaviour {
        public bool insideCollider;
        public GameObject interactText;
        public MeshFilter theMesh;
        public GameObject lightGameObject;

        private void Start() {
            interactText.SetActive(false);
        }

        private void Update() {
            if (insideCollider) {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    theMesh = lightGameObject.GetComponent<MeshFilter>();
                    theMesh.sharedMesh = Resources.Load<Mesh>("Emissive 4");
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