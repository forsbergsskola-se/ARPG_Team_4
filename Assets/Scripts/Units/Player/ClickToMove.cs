using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Units.Player {
    public class ClickToMove : MonoBehaviour{

        public LayerMask whatCanBeClickedOn;
        private NavMeshAgent myAgent;
        private UnityEngine.Camera mainCamera;
        public HealthScriptableObject healthScriptableObject;
        private bool _inputDisabled;
        void Start() {
            myAgent = GetComponent<NavMeshAgent>();
            mainCamera = UnityEngine.Camera.main;

            healthScriptableObject.OnDeath += DisableInput;
            
            if (mainCamera == null) {
                throw new Exception("Main camera is null: Camera needs MainCamera tag.");
            }
        }

        void Update() {
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
    }
}

