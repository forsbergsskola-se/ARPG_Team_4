using System;
using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {
    [SerializeField] private int mouseButton = 1;
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackRadius = 2f;
    [SerializeField] private float attacksPerSecond = 1f;
    [SerializeField] private LayerMask enemyLayers;
    private float _nextAttackTime;
    private float _time;
    private bool _inputDisabled;
    public int AttackDamage => attackDamage;
    private Vector3 AttackPoint => transform.TransformPoint(0, 0, attackRange);
    //TODO make character turn towards mouse target when attacking
    
    private void Update() {
        _time = Time.time;
        if (_inputDisabled)
            return;
        
        if (Time.time >= _nextAttackTime) {
            if (Input.GetMouseButtonDown(mouseButton)) {
                Attack();
                _nextAttackTime = Time.time + 1f / attacksPerSecond;
            }
        }
    }

    private void Attack() {
        Collider[] enemiesHit = Physics.OverlapSphere(AttackPoint, attackRadius, enemyLayers);

        foreach (var enemy in enemiesHit) {
            Debug.Log($"{enemy.name} was hit for {attackDamage} damage.");
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(AttackPoint, attackRadius);
    }

    // private IEnumerator SpawnAttackCollider(float time) {
    //     var attackCollider = Instantiate(meleeHurtboxPrefab,  
    //                                 transform.TransformPoint(0, 0, attackRange), Quaternion.identity);
    //     attackCollider.transform.SetParent(transform);
    //     
    //     yield return new WaitForSeconds(time);
    //     
    //     Destroy(attackCollider);
    // }
}
