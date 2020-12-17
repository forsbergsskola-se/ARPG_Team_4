using System;
using UnityEngine;

namespace Interactables {
    public class RotatingObject : MonoBehaviour {
        [SerializeField] private float rotationSpeed = 100f;
        private void FixedUpdate() {
            Rotate();
        }

        private void Rotate() {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}
