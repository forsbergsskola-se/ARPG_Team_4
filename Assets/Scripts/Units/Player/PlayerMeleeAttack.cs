using System;
using StateMachine;
using Units.EnemyAI;
using UnityEngine;

namespace Units.Player {
    public class PlayerMeleeAttack : MonoBehaviour {
        [SerializeField] private int attackDamage;
        [SerializeField] private float attackRange = 2f;
        [SerializeField] private float attackRadius = 2f;
        [SerializeField] private float attacksPerSecond = 1f;
        [SerializeField] private LayerMask enemyLayers;
        private GameObject _target;

        private UnityEngine.Camera _mainCamera;
        private FSMWorkWithAnimation _FSMWorkWithAnimation;
        public LayerMask whatCanBeClickedOn;
        private float _nextAttackTime;
        private bool _inputDisabled;
        private Vector3 AttackPoint => transform.TransformPoint(0, 0, attackRange);
        private float _attackTime;

        private void Start() {
            _mainCamera = UnityEngine.Camera.main;
            _FSMWorkWithAnimation = GetComponent<FSMWorkWithAnimation>();
            
            _attackTime = 1f / attacksPerSecond;
        }

        public void TryAttack(GameObject target) {
            if (CanAttack()) {
                Attack(target);
            }
        }
        
        public bool WithinAttackRange(Vector3 target) {
            var distance = (target - transform.position).magnitude;
            return attackRange > distance;
        }

        private bool CanAttack() {
            return !_inputDisabled && Time.time >= _nextAttackTime;
        }

        private void Attack(GameObject target) {
            transform.LookAt(GetMousePosition());
            _nextAttackTime = Time.time + _attackTime;
            
            //DoSingleTargetDamage(target);
            _target = target;

            //Melee Audio
            FMODUnity.RuntimeManager.PlayOneShot("event:/Weapons/Crowbar", transform.position);
            _FSMWorkWithAnimation.playerIsAttacking = true;
        }

        private void DoSingleTargetDamage() {
            Debug.Log("Do single target damage");
            if (_target != null)
                _target.GetComponent<IDamagable>().TakeDamage(attackDamage);
        }

        private void DoAreaDamage() {
            Collider[] enemiesHit = Physics.OverlapSphere(AttackPoint, attackRadius, enemyLayers);

            foreach (var enemy in enemiesHit) {
                Debug.Log($"{enemy.name} was hit for {attackDamage} damage.");
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
        }

        private void OnDrawGizmosSelected() {
            Gizmos.DrawWireSphere(AttackPoint, attackRadius);
        }

        private Vector3 GetMousePosition() {
            Ray myRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Vector3 hitLocation = Vector3.zero;
            
            if (Physics.Raycast(myRay, out hitInfo, 1000, whatCanBeClickedOn)) {
                hitLocation = hitInfo.point;
            }

            return hitLocation;
        }

        /*
        public void DoSingleTargetDamage() {
            Debug.Log("Do single target damage");
            if (_target != null)
                _target.GetComponent<IDamagable>().TakeDamage(attackDamage);
        }*/
    }
}
