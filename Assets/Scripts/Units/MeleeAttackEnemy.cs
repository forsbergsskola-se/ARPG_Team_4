using Units.Player;
using UnityEngine;

public class MeleeAttackEnemy : MonoBehaviour {
    public float attackRange = 2f;
    public float attacksPerSecond = 1f;
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackRadius = 2f;
    [SerializeField] private LayerMask enemyLayers;
    private Vector3 AttackPoint => transform.TransformPoint(0, 0, attackRange);
    
    public void Attack() {
        Collider[] enemiesHit = Physics.OverlapSphere(AttackPoint, attackRadius, enemyLayers);

        foreach (var enemy in enemiesHit) {
            Debug.Log($"{enemy.name} was hit for {attackDamage} damage.");
            enemy.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(AttackPoint, attackRadius);
    }
}