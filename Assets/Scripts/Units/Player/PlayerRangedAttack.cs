using Units.Projectiles;
using UnityEngine;
using UnityEngine.Serialization;

// TODO limited bullets.
// TODO art for bullet or other primitive? Make sure it is rotated correctly.
namespace Units.Player {
    public class PlayerRangedAttack : MonoBehaviour
    {
        // references
        public Projectile projectilePrefab = null;
        [Tooltip("The position where the projectile will be fired from")] public Transform firingPosition;

        // parameters
        [SerializeField] private float targetRange = 10f;
        [SerializeField] private float buildUpTime = 0.2f;
        [SerializeField] private float projectileVelocity = 20f;
        [SerializeField] private float projectileMaxDistance = 30f;
        [SerializeField] private int damage = 10;
        [SerializeField] private float attackCoolDown = 1f;

        // variables
        private FSMWorkWithAnimation _FSMWorkWithAnimation;
        private bool _inputDisabled;
        private float _nextAttackTime;
        private float _buildUpTimer;
        public bool AttackIsReady => Time.time >= _nextAttackTime;
        public bool BuildUpIsDone => Time.time >= _buildUpTimer;
        
        private void Start() {
            _FSMWorkWithAnimation = GetComponent<FSMWorkWithAnimation>();
        }
        
        
        public void StartRangedAttack() {
            _buildUpTimer = Time.time + buildUpTime;
        }
        public bool TargetWithinAttackRange(Vector3 target) {
            return (target - transform.position).magnitude <= targetRange;
        }

        public void FireProjectile(Vector3 target) {
            var projectileInstance = Instantiate(projectilePrefab, firingPosition.position, firingPosition.rotation);
            projectileInstance.Setup(damage, projectileVelocity, projectileMaxDistance, GetShootDir(target));
            _nextAttackTime = Time.time + attackCoolDown;
            
            _FSMWorkWithAnimation.playerIsAttacking = true;
        }

        private Vector3 GetShootDir(Vector3 target) {
            Vector3 transformPos = transform.position;
            return new Vector3(target.x - transformPos.x, 0.0f, target.z - transformPos.z).normalized;
        }
    }
}