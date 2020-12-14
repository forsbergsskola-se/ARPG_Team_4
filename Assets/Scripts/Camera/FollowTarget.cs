using System;
using UnityEngine;

namespace Camera {
    public class FollowTarget : MonoBehaviour {
        private UnityEngine.Camera _mainCamera;
        private Transform _playerTransform;
        public float cameraAngle = 55f;
        public float offsetXZ = -10f;
        private Vector3 _verticalOffset;

        private void Awake() {
            _mainCamera = UnityEngine.Camera.main;
           try {
               _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
           }
           catch (NullReferenceException) {
               Debug.Log($"There is no GameObject with the Player tag in the scene!");
           }

           SetRotationAndOffset();
        }

        private void LateUpdate() {
            //TODO Remove SetPosition() from LateUpdate() when Designers have settled on an angle and offset value 
            SetRotationAndOffset();
            
            _mainCamera.transform.position = _playerTransform.position + _verticalOffset;
        }
        
        private void SetRotationAndOffset() {
            transform.rotation = Quaternion.Euler(cameraAngle, 45f, 0f);
            _verticalOffset = new Vector3(offsetXZ, 20f, offsetXZ);
        }
    }
}
