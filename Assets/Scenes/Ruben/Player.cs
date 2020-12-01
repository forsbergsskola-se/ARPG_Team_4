using UnityEngine;
using UnityEngine.AI;

namespace Scenes.Ruben {
    public class Player : MonoBehaviour {

        public LayerMask canBeClicked;
        public NavMeshAgent myAgent;
        public Camera mainCamera;
        void Awake() {
            myAgent = GetComponent<NavMeshAgent>();
        }

        void Update() {
            if (Input.GetMouseButton(0)) {
                var myRay = mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(myRay, out var hitInfo, 500, canBeClicked)) {
                    myAgent.SetDestination(hitInfo.point);
                }
            }
        }
    }
}
