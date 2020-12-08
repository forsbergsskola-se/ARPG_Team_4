using System.Collections;
using UnityEngine;
using UnityEngine.AI;

// TRACKING THREAT
namespace Units.EnemyAI {
    public class TrackPlayer : MonoBehaviour {
        private WaypointMovement waypointMovement;
        private MeleeAttackEnemy meleeAttackEnemy;
        private NavMeshAgent _enemy;
        public GameObject player;
        public float enemyViewDistance = 7f;
        public float enemyIdleTime = 3f;
        private bool _chasing;
        private float _nextAttackTime;

        private void Start() {
            waypointMovement = GetComponent<WaypointMovement>();
            meleeAttackEnemy = GetComponent<MeleeAttackEnemy>();
            if (waypointMovement == null)
                Debug.LogWarning("Patrol point(s) not found", this);
            _enemy = GetComponent<NavMeshAgent>();
        }

        private void Update() {
            var distance = Vector3.Distance(transform.position, player.transform.position);
            
            if (_chasing) {
                var enemyPos = transform.position;
                var dirToPlayer = enemyPos - player.transform.position;
                var newPos = enemyPos - dirToPlayer;
                _enemy.SetDestination(newPos);
                if (distance <= meleeAttackEnemy.attackRange) {
                    if (Time.time < _nextAttackTime) 
                        return;
                    
                    meleeAttackEnemy.Attack();
                    _nextAttackTime = Time.time + 1f / meleeAttackEnemy.attacksPerSecond;
                }
            }
            if (distance < enemyViewDistance) {
                _chasing = true;
            } else if (_chasing && distance > enemyViewDistance) {
                StartCoroutine(wait());
            } else {
                waypointMovement.SetDestination();
            }
        }

        public IEnumerator wait(){
            var enemyPos = transform.position;
            _enemy.SetDestination(enemyPos);
            yield return new WaitForSecondsRealtime(enemyIdleTime);
            _chasing = false;
        }
    }
}
