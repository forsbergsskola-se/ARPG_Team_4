using Units.Projectiles;
using UnityEngine;

// TODO limited bullets.
// TODO art for bullet or other primitive? Make sure it is rotated correctly.
namespace Units.Player {
    public class PlayerRangedAttack : MonoBehaviour
    {
        // references
        public Projectile projectilePrefab = null;
        [Tooltip("The position where the projectile will be fired from")] public Transform firingPosition;

        // parameters
        [SerializeField] private float _attackRange = 10f; 
        [SerializeField] private float projectileVelocity = 10f;
        [SerializeField] private int damage = 10;
        [SerializeField] private float attacksPerSecond = 1f;

        // variables
        private bool _inputDisabled;
        private float _nextAttackTime;
        private float _attackTime;

        public bool ChargeIsReady => Time.time >= _nextAttackTime;
        public void SetNextAttackTime() {
            _nextAttackTime = Time.time + _attackTime;
        }
        private void Start() {
            _attackTime = 1f / attacksPerSecond;
        }
    
        public bool TargetWithinAttackRange(Vector3 target) {
            return (target - transform.position).magnitude <= _attackRange;
        }

        public void FireProjectile(Vector3 target) {
            //fire bullet animation
            var projectileInstance = Instantiate(projectilePrefab, firingPosition.position, firingPosition.rotation);
            projectileInstance.Setup(damage, projectileVelocity, GetShootDir(target));
            _nextAttackTime = Time.time + _attackTime;
        }

        private Vector3 GetShootDir(Vector3 target) {
            Vector3 transformPos = transform.position;
            return new Vector3(target.x - transformPos.x, 0.0f, target.z - transformPos.z).normalized;
        }
    }
}