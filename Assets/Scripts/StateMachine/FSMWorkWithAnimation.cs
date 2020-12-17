using System;
using System.Collections;
using Units.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
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
        
        private bool _crowbarIsReady;
        private const string CrowbarUnlockedKey = "Team4_ARPG_CrowbarUnlocked";
        private bool _gunIsReady;
        private const string GunUnlockedKey = "Team4_ARPG_GunUnlocked";
        public UnityAction OnWeaponSwitch;
        
        public bool GunIsReady
        {
            get => _gunIsReady;
            private set {
                _gunIsReady = value;
                _crowbarIsReady = !value;
                OnWeaponSwitch();
            }
        }
        
        public bool CrowbarIsReady
        {
            get => _crowbarIsReady;
            private set {
                _crowbarIsReady = value;
                _gunIsReady = !value;
                OnWeaponSwitch();
            }
        }

        private bool CrowbarIsUnlocked {
            get {
                var savedValue = PlayerPrefs.GetString(CrowbarUnlockedKey, "false");
                switch (savedValue) {
                    case "false":
                        return false;
                    case "true":
                        return true;
                    default:
                        return false;
                }
            }
            set => PlayerPrefs.SetString(CrowbarUnlockedKey, value ? "true" : "false");
        }
        
        private bool GunIsUnlocked {
            get {
                var savedValue = PlayerPrefs.GetString(GunUnlockedKey, "false");
                switch (savedValue) {
                    case "false":
                        return false;
                    case "true":
                        return true;
                    default:
                        return false;
                }
            }
            set => PlayerPrefs.SetString(GunUnlockedKey, value ? "true" : "false");
        }

        public enum StateWeapon{Unarmed, CrowBar, Gun}
        public enum StateMove{Idle, Running, CrouchIdle, CrouchMove, Dead}
    
        public StateWeapon stateWeapon = StateWeapon.Unarmed;
        public StateMove stateMove = StateMove.Idle;

        public void EquipCrowbar() {
            stateWeapon = StateWeapon.CrowBar;
            CrowbarIsUnlocked = true;
        }

        public void EquipGun() {
            stateWeapon = StateWeapon.Gun;
            GunIsUnlocked = true;
        }

        void Start(){ 
            _animator = GetComponent<Animator>();
            _playerHealth = GetComponent<PlayerHealth>(); 
        
            stateWeapon = StateWeapon.Unarmed;
            stateMove = StateMove.Idle;
        
            _previousPos = transform.position;
            _playerHealth.GetDamaged.AddListener(TakeDamageState);

            if (SceneManager.GetActiveScene().buildIndex == 0) {
                PlayerPrefs.DeleteAll();
            }
        }

        private void Update() {
            if (Input.GetKey(KeyCode.Alpha1) && CrowbarIsUnlocked) EquipCrowbar();
            else if (Input.GetKey(KeyCode.Alpha2) && GunIsUnlocked) EquipGun();

            if (stateWeapon == StateWeapon.Gun && Input.GetMouseButton(1)) playerIsAiming = true;
            else playerIsAiming = false;

            if (Mathf.Abs(_previousPos.x - transform.position.x) > positionUpdateOffset ||
                Mathf.Abs(_previousPos.z - transform.position.z) > positionUpdateOffset) {
                playerIsMoving = true;
            } else playerIsMoving = false;
   
            if (_playerHealth.healthScriptableObject.CurrentHealth <= 0) stateMove = StateMove.Dead;
        
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
        }
        
        private void LateUpdate() {
            _previousPos = transform.position;
        }
    
        private void TakeDamageState() {
            playerTookDamage = true;
            StartCoroutine(GracePeriod());
        }

        private IEnumerator GracePeriod(){
            yield return new WaitForSecondsRealtime(1.5f);
            playerIsAttacking = false;
        }
    
        private void FixTiltOfCharacter() {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles = new Vector3(0, eulerAngles.y, eulerAngles.z);
            transform.eulerAngles = eulerAngles;
        }
    }
}
