using System;
using UnityEngine;
using UnityEngine.AI;

namespace Player {
    public class ClickToMove : MonoBehaviour{

        public LayerMask whatCanBeClickedOn;
        private NavMeshAgent myAgent;
        private Camera mainCamera;
        void Start() {
            myAgent = GetComponent<NavMeshAgent>();
            mainCamera = Camera.main;
            
            if (mainCamera == null) {
                throw new Exception("Main camera is null: Camera needs MainCamera tag.");
            }
        }

        void Update() {
            if (Input.GetMouseButton(0)) {
                Ray myRay = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
            
                if (Physics.Raycast(myRay, out hitInfo, 1000, whatCanBeClickedOn)){
                    myAgent.SetDestination(hitInfo.point);
                }
            }
        }
    }
}
