using UnityEngine;

namespace Camera {
    public class FollowTarget : MonoBehaviour {
        public Transform myCamera;
        public Transform target;
        public Vector3 offset;

        void Update() {
            myCamera.position = target.position + offset;
        }
    }
}
