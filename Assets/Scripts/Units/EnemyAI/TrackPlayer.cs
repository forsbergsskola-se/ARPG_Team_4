using System.Collections;
using UnityEngine;
using UnityEngine.AI;

// TRACKING THREAT
namespace Units.EnemyAI {
    public class TrackPlayer : MonoBehaviour {
        private WaypointMovement waypointMovement;
        private NavMeshAgent _enemy;
        public GameObject player;
        public float enemyViewDistance = 7f;
        public float enemyIdleTime = 3f;
        private bool chasing;

        private void Start() {
            waypointMovement = GetComponent<WaypointMovement>();
            if (waypointMovement == null)
                Debug.LogWarning("Patrol point(s) not found", this);
            _enemy = GetComponent<NavMeshAgent>();
        }

        private void Update() {
            var distance = Vector3.Distance(transform.position, player.transform.position);
            
            if (chasing) {
                var enemyPos = transform.position;
                var dirToPlayer = enemyPos - player.transform.position;
                var newPos = enemyPos - dirToPlayer;
                _enemy.SetDestination(newPos);
            }

            if (distance < enemyViewDistance) {
                chasing = true;
            } else if (chasing && distance > enemyViewDistance) {
                StartCoroutine(wait());
            } else {
                waypointMovement.SetDestination();
            }
        }

        public IEnumerator wait(){
            var enemyPos = transform.position;
            _enemy.SetDestination(enemyPos);
            yield return new WaitForSecondsRealtime(enemyIdleTime);
            chasing = false;
        }
    }
}
