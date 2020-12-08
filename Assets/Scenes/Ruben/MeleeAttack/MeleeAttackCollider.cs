using Units;
using UnityEngine;

public class MeleeAttackCollider : MonoBehaviour {
    private int _attackDamage;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
            return;
        
        var target = other.GetComponent<IDamagable>();
        _attackDamage = GetComponentInParent<MeleeAttack>().AttackDamage;
        target?.TakeDamage(_attackDamage);
    }
}
