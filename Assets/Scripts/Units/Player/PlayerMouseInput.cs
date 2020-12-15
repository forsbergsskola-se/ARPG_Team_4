using UnityEngine;

//TODO check that knockback works, check that disable input from menus etc works.
namespace Units.Player {
    [RequireComponent(typeof(MeleeAttack))]
    [RequireComponent(typeof(PlayerRangedAttack))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerMouseInput : MonoBehaviour {
        [SerializeField] private LayerMask walkableLayers;
        [SerializeField] private LayerMask enemyLayers;
        public HealthScriptableObject healthScriptableObject;
        private GameObject _target;
        private UnityEngine.Camera _mainCamera;

        private MeleeAttack _meleeAttack;
        private PlayerMovement _playerMovement;
        private PlayerRangedAttack _playerRangedAttack;
        private FSMWorkWithAnimation _FSMWorkWithAnimation;

        private bool _rangedAttackCharging = false;
        private bool _inputDisabled = false;

        public bool InputDisabled { set => _inputDisabled = value; }

        public void DisableInput() {
            _inputDisabled = true;
        }

        private void Start() {
            
            _mainCamera = UnityEngine.Camera.main;
            _meleeAttack = GetComponent<MeleeAttack>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerRangedAttack = GetComponent<PlayerRangedAttack>();
            _FSMWorkWithAnimation = GetComponent<FSMWorkWithAnimation>();
            healthScriptableObject.OnDeath += DisableInput;
        }

        private void Update() {

            if (_inputDisabled)
                return;
            
            if (_rangedAttackCharging) {
                HandleRangedAttackCharging();
                return;
            }
            
            Ray myRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
        
            if (IsMouseCursorOnEnemy(myRay, out hitInfo)) {
                _target = hitInfo.collider.gameObject;

                if (Input.GetMouseButtonDown(1)) {
                    RangedAttackCommencing();
                    return;
                }

                _meleeAttack.UpdateCursor(_target.transform.position);
            
                if (Input.GetMouseButtonDown(0)) {
                    if (_meleeAttack.WithinAttackRange(_target.transform.position)) {
                        _meleeAttack.TryAttack(_target);
                        return;
                    }
                }
            }
            else {
                SetDefaultCursor();
            }
        
            if (Physics.Raycast(myRay, out hitInfo, 1000, walkableLayers)) {
                if (Input.GetMouseButton(0))
                    _playerMovement.SetDestination(hitInfo.point);
            }
        }

        private void RangedAttackCommencing() {
            _playerRangedAttack.SetNextAttackTime();
            _rangedAttackCharging = true;
            _FSMWorkWithAnimation.playerIsAiming = _rangedAttackCharging;
            _playerMovement.ResetPath();
        }

        private void HandleRangedAttackCharging() {
            if (RangeChargeBroken())
            {
                _rangedAttackCharging = false;
                _FSMWorkWithAnimation.playerIsAiming = _rangedAttackCharging;
            }
            else {
                transform.LookAt(_target.transform.position);
                if (_playerRangedAttack.ChargeIsReady)
                    _playerRangedAttack.FireProjectile(_target.transform.position);
            }
        }

        private bool RangeChargeBroken() {
            return !Input.GetMouseButton(1) || 
                   _target == null || 
                   !_playerRangedAttack.TargetWithinAttackRange(_target.transform.position);
        }

        private static void SetDefaultCursor() {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        private bool IsMouseCursorOnEnemy(Ray myRay, out RaycastHit hitInfo) {
            return Physics.Raycast(myRay, out hitInfo, 1000, enemyLayers);
        }
    }
}