using UnityEngine;

namespace Camera {
    public class FollowTarget : MonoBehaviour {
        public Transform myCamera;
        public Transform target;
        private Vector3 offset;

        void Awake() {
            offset = myCamera.position;
        }

        void Update() {
            myCamera.position = target.position + offset;
        }
    }
}
