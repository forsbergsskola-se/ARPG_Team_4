using System;
using UnityEngine;
using UnityEngine.AI;

//TODO check that knockback still works.

namespace Units.Player {
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour{

        private NavMeshAgent _myAgent;
        private UnityEngine.Camera _mainCamera;
        //public HealthScriptableObject healthScriptableObject;
        private Rigidbody _rigidbody;
        
        private bool _inputDisabled;
        private bool _knockbackActive = false;

        // Audio Walking Test
        [SerializeField] [FMODUnity.EventRef] private string FootstepEventPath;
        [SerializeField] private float _raycastDistance = 0.5f;
        private RaycastHit _raycastHit;

        /*
        FMOD.Studio.EventInstance FootstepEvent;
        FMOD.Studio.EventInstance.setParameterByName(string name, float value, bool ignoreseekspeed = false);
        public string inputSound;
        bool playersMoving;
        public float walkingSpeed;
        //FMOD.Studio.par 
        */
        public bool InputDisabled {
            set {
                _inputDisabled = value;
                _myAgent.ResetPath();
            }
        }
        
        public void SetDestination(Vector3 target) {
            if (_inputDisabled)
                return;
            
            _myAgent.SetDestination(target);
        }
        
        public void ResetPath() {
            _myAgent.ResetPath();
        }
        
        void Start() {
            GetComponent<Rigidbody>().isKinematic = true;
            _myAgent = GetComponent<NavMeshAgent>();
            _mainCamera = UnityEngine.Camera.main;

            //healthScriptableObject.OnDeath += DisableInput;
            
            if (_mainCamera == null) {
                throw new Exception("Main camera is null: Camera needs MainCamera tag.");
            }

            _rigidbody = GetComponent<Rigidbody>();

            // Audio Walking Test
            // InvokeRepeating("PlayerIsWalking", 0, walkingSpeed);
        }

        void Update() {
            if (_knockbackActive) {
                if (_rigidbody.velocity.magnitude < 2f)
                    DisableKnockback();
            }
        }
        
        // Audio Walking Test
        void FloorCheck()
        {
            Physics.Raycast(transform.position, Vector3.down, out _raycastHit, _raycastDistance);
            //if(raycastHit.collider)
                

        }
        void PlayerMoveSound()
        {
            FMOD.Studio.EventInstance Footstep = FMODUnity.RuntimeManager.CreateInstance(FootstepEventPath);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(Footstep, transform, GetComponent<Rigidbody>());
        }

        /*
        void PlayerIsWalking()
        {
            if (playersMoving == true)
            {
                FMODUnity.RuntimeManager.PlayOneShot(inputSound);
                Debug.Log("Player Walking Audio Plays");
            }
        }
        */


        public void Knockback(Vector3 velocity) {
            _knockbackActive = true;
            _rigidbody.isKinematic = false;
            _myAgent.updatePosition = false;
            _rigidbody.velocity = velocity;
        }

        private void DisableKnockback() {
            _knockbackActive = false;
            _rigidbody.isKinematic = true;
            _myAgent.nextPosition = _rigidbody.position;
            _myAgent.ResetPath();
            _myAgent.updatePosition = true;
        }

    }
}

