using UnityEngine;

namespace Units.EnemyAI {
    public class MeleeAttackEnemy : MonoBehaviour {
        public float attackRange = 2f;
        public float attacksPerSecond = 1f;
        [SerializeField] private int attackDamage;

        public void Attack(GameObject player) {
            if (player.CompareTag("Player")) {
                player.GetComponent<IDamagable>().TakeDamage(attackDamage);
            }
        }
    }
}