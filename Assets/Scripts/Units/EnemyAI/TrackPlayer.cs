using Units.Player;
using UnityEditor.Experimental.GraphView;
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
        private Transform _playerTransform;
        public float enemyViewDistance = 6f;
        private float _nextAttackTime;
        public HealthScriptableObject playerHealth;

        //Audio
        public int enemyAudioInterval = 0;
        public float _enemyAudioInterval = 0f;

        private void Start() {
            waypointMovement = GetComponent<WaypointMovement>();
            meleeAttackEnemy = GetComponent<MeleeAttackEnemy>();
            _enemy = GetComponent<NavMeshAgent>();
            _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            
            if (_playerTransform == null)
                Debug.LogError("There is no GameObject with the Player tag in the scene", this);
            
            if (waypointMovement == null) 
                Debug.LogWarning("Patrol point(s) not found", this);
        }

        void FixedUpdate() {
            var enemyPos = transform.position;
            var distance = Vector3.Distance(enemyPos, _playerTransform.position);

            if (CanSeePlayer()) {
                var dirToPlayer = enemyPos - _playerTransform.position;
                var newPos = enemyPos - dirToPlayer;
                    _enemy.SetDestination(newPos);
                if (distance <= meleeAttackEnemy.attackRange) {
                    _enemy.ResetPath();
                    if (Time.time < _nextAttackTime) return;
                    meleeAttackEnemy.Attack();
                    _nextAttackTime = Time.time + 1f / meleeAttackEnemy.attacksPerSecond;
                }
            } else {
                waypointMovement.SetDestination();
            }
        }
        
        // private bool PathComplete() {
        //     if (_enemy.remainingDistance < 1) {
        //         Debug.Log("Enemy Reset ");
        //         enemyAudioInterval -= 1;
        //         return true;
        //     }
        //     return false;
        // }

        bool CanSeePlayer() {
            RaycastHit hit;
            Vector3 rayDirection = _playerTransform.position - transform.position;

            if (Vector3.Angle(rayDirection, transform.forward) <= 360 * 0.5f) {
                if (Physics.Raycast(transform.position, rayDirection, out hit, enemyViewDistance)) {
                    if (hit.transform.CompareTag("Player") && playerHealth.CurrentHealth > 0){
                        EnemyAudio();
                        return true;
                    }
                }
            }
            return false;
        }
        
        void EnemyAudio()
        {
            if(enemyAudioInterval < 1)
            {
                enemyAudioInterval += 1;
                FMODUnity.RuntimeManager.PlayOneShot("event:/THESPLIT/CharacterSplit/EnemyScreechSplit/EnemyScreechSplit", GetComponent<Transform>().position);
            }
        }
    }
} 

