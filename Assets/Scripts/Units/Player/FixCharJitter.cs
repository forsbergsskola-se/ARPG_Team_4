using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Units.Player {
    public class FixCharJitter : MonoBehaviour
    {
        private NavMeshAgent _myAgent;
        private Rigidbody _rb;
        private FSMWorkWithAnimation _fsm;
        private const float TimerSeconds = 0.1f;
        private float _deltaTimer = TimerSeconds;
        private int _tickTest = 10;

        void Start() {
            _fsm = GetComponent<FSMWorkWithAnimation>();
            _rb = GetComponent<Rigidbody>();
            _myAgent = GetComponent<NavMeshAgent>();
        }
        void LateUpdate() {
            //todo fix this lazy ass shit
            if (_fsm.playerTookDamage && _tickTest < 0) {
                _tickTest = 10;
                _fsm.playerTookDamage = false;
            }
            _tickTest--;
            
            if (!_fsm.playerIsMoving) {
                _deltaTimer -= Time.deltaTime;
                if (_deltaTimer < 0f) {
                    _rb.velocity = Vector3.zero;
                    _rb.angularVelocity = Vector3.zero;
                    _myAgent.velocity = Vector3.zero;
                    _myAgent.ResetPath();
                    _deltaTimer = TimerSeconds;
                }
            }
            else _deltaTimer = TimerSeconds;
        }
    }
}

