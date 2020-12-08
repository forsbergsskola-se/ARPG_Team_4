using System;
using UnityEngine;
using UnityEngine.AI;


namespace Units.Player {
    [RequireComponent(typeof(Rigidbody))]
    public class ClickToMove : MonoBehaviour{

        public LayerMask whatCanBeClickedOn;
        private NavMeshAgent myAgent;
        private UnityEngine.Camera mainCamera;
        public HealthScriptableObject healthScriptableObject;
        private Rigidbody _rigidbody;
        
        private bool _inputDisabled;
        private bool _knockbackActive = false;
        
        
        public bool InputDisabled {
            set {
                _inputDisabled = value;
                myAgent.ResetPath();
            }
        }
        
        void Start() {
            myAgent = GetComponent<NavMeshAgent>();
            mainCamera = UnityEngine.Camera.main;

            healthScriptableObject.OnDeath += DisableInput;
            
            if (mainCamera == null) {
                throw new Exception("Main camera is null: Camera needs MainCamera tag.");
            }

            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update() {

            if (_knockbackActive) {
                if (_rigidbody.velocity.magnitude < 2f)
                    DisableKnockback();
                return;
            }

            if (_inputDisabled) {
                myAgent.SetDestination(transform.position);
                return;
            }
            if (Input.GetMouseButton(0)) {
                Ray myRay = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
            
                if (Physics.Raycast(myRay, out hitInfo, 1000, whatCanBeClickedOn)){
                    myAgent.SetDestination(hitInfo.point);
                }
            }
        }

        private void DisableInput() {
            _inputDisabled = true;
        }

        public void Knockback(Vector3 velocity) {
            _knockbackActive = true;
            _rigidbody.isKinematic = false;
            myAgent.updatePosition = false;
            _rigidbody.velocity = velocity;
        }

        private void DisableKnockback() {
            _knockbackActive = false;
            _rigidbody.isKinematic = true;
            myAgent.nextPosition = _rigidbody.position;
            myAgent.updatePosition = true;
        }
    }
}

