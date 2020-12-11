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

        void Start() {
            _fsm = GetComponent<FSMWorkWithAnimation>();
            _rb = GetComponent<Rigidbody>();
            _myAgent = GetComponent<NavMeshAgent>();
        }
        void LateUpdate() {
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

