using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class MeleeAttack : MonoBehaviour {
    [SerializeField] private GameObject meleeHurtboxPrefab;
    [SerializeField] private int mouseButton = 1;
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackDuration = 0.1f;
    [SerializeField] private float attackCooldown = 1f;
    private float _timeOnLastAttack;
    private bool _inputDisabled;
    public int AttackDamage => attackDamage;
    
    //TODO make character turn towards mouse target when attacking
    
    private void Update() {
        if (_inputDisabled)
            return;
        
        if (Input.GetMouseButtonDown(mouseButton)) {
            if (Time.time - _timeOnLastAttack >= attackCooldown) {
                Attack();
            }
        }
    }

    private void Attack() {
        _timeOnLastAttack = Time.time;
        
        StartCoroutine(SpawnAttackCollider(attackDuration));
    }

    private IEnumerator SpawnAttackCollider(float time) {
        var attackCollider = Instantiate(meleeHurtboxPrefab,  
                                    transform.TransformPoint(0, 0, attackRange), Quaternion.identity);
        attackCollider.transform.SetParent(transform);

        yield return new WaitForSeconds(time);
        
        Destroy(attackCollider);
    }
}
