using System;
using UnityEngine;

namespace Camera {
    public class FollowTarget : MonoBehaviour {
        public Transform myCamera;
        public Transform target;
        public float cameraAngle = 55f;
        public float offsetXZ = -10f;
        private Vector3 _verticalOffset;

        private void Awake() {
            SetRotationAndOffset();
        }

        private void LateUpdate() {
            // Remove SetPosition() from LateUpdate() when Designers have settled on an angle and offset value 
            SetRotationAndOffset();
            
            myCamera.position = target.position + _verticalOffset;
        }
        
        private void SetRotationAndOffset() {
            transform.rotation = Quaternion.Euler(cameraAngle, 45f, 0f);
            _verticalOffset = new Vector3(offsetXZ, 20f, offsetXZ);
        }
    }
}
