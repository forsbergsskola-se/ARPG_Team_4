using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

// TRACKING THREAT
namespace Units.EnemyAI
{
    public class TrackPlayer : MonoBehaviour
    {
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
            if (waypointMovement == null) Debug.LogWarning("Patrol point(s) not found", this);
            _enemy = GetComponent<NavMeshAgent>();
        }

        void FixedUpdate() {
            var enemyPos = transform.position;
            var _chasing = CanSeePlayer();
            var distance = Vector3.Distance(enemyPos, player.transform.position);

            if (_chasing) {
                var dirToPlayer = enemyPos - player.transform.position;
                var newPos = enemyPos - dirToPlayer;
                _enemy.SetDestination(newPos);
                if (distance <= meleeAttackEnemy.attackRange) {
                    if (Time.time < _nextAttackTime) return;

                    meleeAttackEnemy.Attack();
                    _nextAttackTime = Time.time + 1f / meleeAttackEnemy.attacksPerSecond;
                }
            }
            // else if () {
            //     StartCoroutine(wait());{
             else {
                waypointMovement.SetDestination();
            }
        }

        bool CanSeePlayer() {
            RaycastHit hit;
            Vector3 rayDirection = player.transform.position - transform.position;

            if ((Vector3.Angle(rayDirection, transform.forward)) <= 180 * 0.5f) {
                // Detect if player is within the field of view
                if (Physics.Raycast(transform.position, rayDirection, out hit, enemyViewDistance)) {
                    return (hit.transform.CompareTag("Player"));
                }
            }

            return false;
        }
        
        //  public IEnumerator wait(){
        //      var enemyPos = transform.position;
        //      _enemy.SetDestination(enemyPos);
        //      yield return new WaitForSecondsRealtime(enemyIdleTime);
        //      _chasing = false;
        // }
    }
} 

