using UnityEngine;
using UnityEngine.AI;

// TRACKING THREAT
namespace Units.EnemyAI {
    public class DetectPlayerInRange : MonoBehaviour {
        private WaypointMovement waypointMovement;
        private NavMeshAgent _enemy;
        public GameObject player;
        public float enemyViewDistance = 6f;
        public float enemyIdleTime = 8f;

        private void Start() {
            waypointMovement = GetComponent<WaypointMovement>();
            if (waypointMovement == null)
                Debug.LogWarning("Patrol threat not found", this);
            _enemy = GetComponent<NavMeshAgent>();
        }

        private void Update() {
            var distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < enemyViewDistance) {
                var enemyPos = transform.position;
                var dirToPlayer = enemyPos - player.transform.position;
                var newPos = enemyPos - dirToPlayer;
                _enemy.SetDestination(newPos);
            } else {
                waypointMovement.Invoke("SetDestination", enemyIdleTime);
            }
        }
    }
}
