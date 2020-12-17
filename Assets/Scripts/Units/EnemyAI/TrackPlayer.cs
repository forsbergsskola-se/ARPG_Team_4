using Units.Player;
using UnityEngine;
using UnityEngine.AI;

// TRACKING THREAT
namespace Units.EnemyAI {
    public class TrackPlayer : MonoBehaviour {
        private WaypointMovement waypointMovement;
        private MeleeAttackEnemy meleeAttackEnemy;
        private NavMeshAgent _enemy;
        private Transform PlayerTransform => GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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

            if (waypointMovement == null) 
                Debug.LogWarning("Patrol point(s) not found", this);
        }

        private void FixedUpdate() {
            var enemyPos = transform.position;
            var distance = Vector3.Distance(enemyPos, PlayerTransform.position);

            if (CanSeePlayer()) {
                var dirToPlayer = enemyPos - PlayerTransform.position;

                if (distance <= meleeAttackEnemy.attackRange) {
                    _enemy.ResetPath();
                    if (Time.time >= _nextAttackTime) {
                        transform.LookAt(PlayerTransform.position);
                        meleeAttackEnemy.Attack(PlayerTransform.gameObject);
                        _nextAttackTime = Time.time + 1f / meleeAttackEnemy.attacksPerSecond;
                    }
                } else {
                    var newPos = enemyPos - dirToPlayer;
                    _enemy.SetDestination(newPos);
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

        private bool CanSeePlayer() {
            RaycastHit hit;
            Vector3 rayDirection = PlayerTransform.position - transform.position;

            // if (Physics.CheckSphere(transform.position, enemyViewDistance))
            if (Physics.Raycast(transform.position, rayDirection, out hit, enemyViewDistance)) {
                if (hit.transform.CompareTag("Player") && playerHealth.CurrentHealth > 0){
                    EnemyAudio();
                    return true;
                }
            }
            return false;
        }
        
        void EnemyAudio()
        {
            if(enemyAudioInterval < 1)
            {
                enemyAudioInterval += 1;
                EnemySound(true);
                //FMODUnity.RuntimeManager.PlayOneShot("event:/THESPLIT/CharacterSplit/EnemyScreechSplit/EnemyScreechSplit", GetComponent<Transform>().position);
            }
        }
        private void EnemySound(bool setEnemySFX)
        {
            var AT = FindObjectOfType<Audio_Character_Controller>();
            AT.EnemySFXSet(setEnemySFX);
        }
        /*
        public void EnemySFXSet(bool setEnemySFX)
        {
            var AT = FindObjectOfType<Audio_Character_Controller>();
            if (setEnemySFX)
            {
                EnemySFX = FMODUnity.RuntimeManager.CreateInstance(EnemyEvent);
                EnemySFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
                EnemySFX.start();
            }
            else
            {
                EnemySFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }
        }
        */
    }
} 

