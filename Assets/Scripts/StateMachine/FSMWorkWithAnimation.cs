﻿using System.Collections;
using Units.Player;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class FSMWorkWithAnimation : MonoBehaviour{
    private Animator _animator;
    private PlayerHealth _playerHealth;
    private Vector3 _previousPos;
    private const string stateName = "State";
    private const string AnimStateMoveBlend = "StateMove";
    private const string AnimPlayerIsAttacking = "IsAttacking";
    private const string AnimPlayerWeapon = "WeaponInHand";
    private const string AnimPlayerTookDamage = "PlayerTookDamage";
    
    //PlayerStates
    public bool playerIsMoving = false;
    public bool playerTookDamage = false;
    public bool playerIsAttacking = false;
    public bool playerIsCrouching = false;
    public enum StateWeapon{Unarmed, CrowBar, Gun}
    public enum StateMove{Idle, Running, CrouchIdle, CrouchMove, Dead}
    
    public StateWeapon stateWeapon = StateWeapon.Unarmed;
    public StateMove stateMove = StateMove.Idle;
    
    void Start(){ 
        _animator = GetComponent<Animator>();
        _playerHealth = GetComponent<PlayerHealth>(); 
        
        stateWeapon = StateWeapon.Unarmed;
        stateMove = StateMove.Idle;
        
        _previousPos = transform.position;
        _playerHealth.GetDamaged.AddListener(TakeDamageState);
    }
    void Update() {
        if (Mathf.Abs(_previousPos.x - transform.position.x) > 0.015f ||
            Mathf.Abs(_previousPos.z - transform.position.z) > 0.015f) {
            playerIsMoving = true;
        }
        else playerIsMoving = false;

        //playerIsMoving = Input.GetKey(KeyCode.Space);

            //= GetComponent<NavMeshAgent>().velocity.magnitude > 0.1f;
        
        //Debug.Log(GetComponent<NavMeshAgent>().velocity.magnitude);
        //playerIsCrouching = get a bool;
        //if (check player health <= 0) stateMove = StateMove.Dead;
        
        //Check Player Equipped Weapon
        //Todo Create GetEquippedWeapon() script
        //stateWeapon = GetEquippedWeapon()


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
                //Call dead methods here
                break;
        }
        
        switch (stateWeapon) 
        {
            case StateWeapon.Unarmed:
                //Logic
                break;
            case StateWeapon.CrowBar:
                //Logic
                break;
            case StateWeapon.Gun:
                //Logic
                break;
        }
        //_animator.GetBool()

        
        _animator.SetBool(AnimPlayerIsAttacking, playerIsAttacking);
        if (playerIsAttacking) playerIsAttacking = false;

            _animator.SetInteger(AnimPlayerWeapon, (int)stateWeapon + 1);
        _animator.SetInteger(AnimStateMoveBlend, (int)stateMove);

        //set attacking state from bool attacking?
        //set take damage state if health drops, add listener?
        //set death animation with listener on death?
    }
    void LateUpdate() {
        _previousPos = transform.position;
    }
    
    void TakeDamageState() {
        playerTookDamage = true;
        _animator.SetBool(AnimPlayerTookDamage, playerTookDamage);
        StartCoroutine(GracePeriod());
        //change to idle/attack state when damage is done...
    }

    private IEnumerator GracePeriod(){
        yield return new WaitForSecondsRealtime(1.5f);
        playerIsAttacking = false;
        Debug.Log("Player exit damage sector");
    }
}

// TODO create a abstract class of states?
