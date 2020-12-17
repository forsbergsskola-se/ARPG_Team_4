using System.Collections;
using Units.Player;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

namespace StateMachine {
    public class FSMWorkWithAnimation : MonoBehaviour{
        private Animator _animator;
        private PlayerHealth _playerHealth;
        private Vector3 _previousPos;
        private const string AnimPlayerIsAiming = "IsAiming";
        private const string AnimStateMoveBlend = "StateMove";
        private const string AnimPlayerWeapon = "WeaponInHand";
        private const string AnimPlayerIsAttacking = "IsAttacking";
        private const string AnimPlayerTookDamage = "PlayerTookDamage";
    
        //PlayerStates
        public float positionUpdateOffset = 0.01f;
        public bool playerIsAiming = false;
        public bool playerIsMoving = false;
        public bool playerTookDamage = false;
        public bool playerIsAttacking = false;
        public bool playerIsCrouching = false;

        public UnityAction OnWeaponSwitch;

        private bool _gunIsReady;
        public bool GunIsReady
        {
            get => _gunIsReady;
            private set {
                _gunIsReady = value;
                _crowbarIsReady = !value;
                OnWeaponSwitch();
            }
        }

        private bool _crowbarIsReady;
        public bool CrowbarIsReady
        {
            get => _crowbarIsReady;
            private set {
                _crowbarIsReady = value;
                _gunIsReady = !value;
                OnWeaponSwitch();
            }
        }
    
        public enum StateWeapon{Unarmed, CrowBar, Gun}
        public enum StateMove{Idle, Running, CrouchIdle, CrouchMove, Dead}
    
        public StateWeapon stateWeapon = StateWeapon.Unarmed;
        public StateMove stateMove = StateMove.Idle;

        public void EquipCrowbar() {
            stateWeapon = StateWeapon.CrowBar;
        }

        public void EquipGun() {
            stateWeapon = StateWeapon.Gun;
        }

        void Start(){ 
            _animator = GetComponent<Animator>();
            _playerHealth = GetComponent<PlayerHealth>(); 
        
            stateWeapon = StateWeapon.Unarmed;
            stateMove = StateMove.Idle;
        
            _previousPos = transform.position;
            _playerHealth.GetDamaged.AddListener(TakeDamageState);
        }
        void Update() {
            //Check Player Equipped Weapon
            //if (Input.GetKey(KeyCode.Alpha1)) stateWeapon = StateWeapon.Unarmed;
            if (Input.GetKey(KeyCode.Alpha1)) EquipCrowbar();
            else if (Input.GetKey(KeyCode.Alpha2)) EquipGun();

            if (stateWeapon == StateWeapon.Gun && Input.GetMouseButton(1)) playerIsAiming = true;
            else playerIsAiming = false;

            //if (playerIsAiming) Debug.Log("Player is aiming");
        
            //Todo Create GetEquippedWeapon() script
            //stateWeapon = GetEquippedWeapon()

            if (Mathf.Abs(_previousPos.x - transform.position.x) > positionUpdateOffset ||
                Mathf.Abs(_previousPos.z - transform.position.z) > positionUpdateOffset) {
                playerIsMoving = true;
            } else playerIsMoving = false;
   
            if (_playerHealth.healthScriptableObject.CurrentHealth <= 0) stateMove = StateMove.Dead;
        
            //StateMove transition
            switch (stateMove) 
            {
                case StateMove.Idle:
                    if (playerIsMoving) stateMove = StateMove.Running;
                    break;
                case StateMove.Running:
                    if (!playerIsMoving) stateMove = StateMove.Idle;
                    break;
                case StateMove.CrouchIdle:
                    if (!playerIsCrouching) stateMove = playerIsMoving ? StateMove.Running : StateMove.Idle;
                    if (playerIsMoving) stateMove = StateMove.CrouchMove;
                    //TODO Add crouch animation and parameter that check if player is crouching
                    break;
                case StateMove.CrouchMove:                                                                  
                    if (!playerIsCrouching) stateMove = playerIsMoving ? StateMove.Running : StateMove.Idle;
                    if (!playerIsMoving) stateMove = StateMove.CrouchIdle;
                    break;
                case StateMove.Dead:
                    if (_playerHealth.healthScriptableObject.CurrentHealth > 0) stateMove = StateMove.Idle;
                    break;
            }
        
            switch (stateWeapon) 
            {
                case StateWeapon.Unarmed:
                    //Logic
                    break;
                case StateWeapon.CrowBar:
                    if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Draw Crowbar")) 
                        CrowbarIsReady = true;
                    break;
                case StateWeapon.Gun:
                    if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Drawing Gun"))
                        GunIsReady = true;
                    break;
            }

            _animator.SetBool(AnimPlayerIsAiming, playerIsAiming);
            _animator.SetBool(AnimPlayerIsAttacking, playerIsAttacking);
            _animator.SetBool(AnimPlayerTookDamage, playerTookDamage);
            _animator.SetInteger(AnimPlayerWeapon, (int)stateWeapon + 1);
            _animator.SetInteger(AnimStateMoveBlend, (int)stateMove);
        
            if (playerIsAttacking) playerIsAttacking = false;
            if (playerIsAiming) FixTiltOfCharacter();
        
            //set attacking state from bool attacking?
            //set take damage state if health drops, add listener?
            //set death animation with listener on death?
        }
        private void LateUpdate() {
            _previousPos = transform.position;
        }
    
        private void TakeDamageState() {
            playerTookDamage = true;
            //_animator.SetBool(AnimPlayerTookDamage, playerTookDamage);
            StartCoroutine(GracePeriod());
            //change to idle/attack state when damage is done...
        }

        private IEnumerator GracePeriod(){
            yield return new WaitForSecondsRealtime(1.5f);
            playerIsAttacking = false;
            Debug.Log("Player exit damage sector");
        }
    
        private void FixTiltOfCharacter() {
            //Lazy fix, fixes character tilt
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles = new Vector3(0, eulerAngles.y, eulerAngles.z);
            transform.eulerAngles = eulerAngles;
        }
    }
}

// TODO create a abstract class of states?
