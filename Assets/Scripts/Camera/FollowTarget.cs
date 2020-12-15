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
            _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            if (_playerTransform == null)
               Debug.LogError("There is no GameObject with the Player tag in the scene", this);
            SetRotationAndOffset();
        }

        private void LateUpdate() {
            _mainCamera.transform.position = _playerTransform.position + _verticalOffset;
        }
        
        private void SetRotationAndOffset() {
            transform.rotation = Quaternion.Euler(cameraAngle, 45f, 0f);
            _verticalOffset = new Vector3(offsetXZ, 20f, offsetXZ);
        }
        
        void OnValidate() {
            SetRotationAndOffset();
        }
    }
}
