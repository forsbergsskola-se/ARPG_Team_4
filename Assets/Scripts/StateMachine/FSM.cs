using System.Collections;
using Units.Player;
using UnityEngine;
using UnityEngine.AI;

public class FSM : MonoBehaviour{
    public GameObject player;
    private Animator _animator;
    private PlayerHealth _playerHealth;
    private const string stateName = "State";
    public enum State{Idle, Running, MeleeAttack, GunAttack, TakeDamage}
    public State state = State.Idle;
    void Start(){
        _animator = player.GetComponent<Animator>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        state = State.Idle;
        _playerHealth.GetDamaged.AddListener(TakeDamageState);
    }
    void Update()
    {
        if (player.GetComponent<NavMeshAgent>().velocity.magnitude > 0.1f){
            //player moves, set to walk state, if player is not taking damage/attacking.
            if (state != State.GunAttack && state != State.MeleeAttack && state != State.TakeDamage){
                state = State.Running;
                Debug.Log("Player is running");
            }
        }
        else if (player.GetComponent<NavMeshAgent>().velocity.magnitude < 0.1f){
            //player does not move/take damage/attack, set to idle.
            if (state != State.GunAttack && state != State.MeleeAttack && state != State.TakeDamage){
                state = State.Idle;
                Debug.Log("Player is idling");
            }
        }
        
        _animator.SetInteger(stateName, (int) state);
        //set attacking state from bool attacking?
        //set take damage state if health drops, add listener?
        //set death animation with listener on death?
    }

    void TakeDamageState(){
        state = State.TakeDamage;
        Debug.Log("Player took damage");
        StartCoroutine(gracePeriod());
        //change to idle/attack state when damage is done...
    }

    private IEnumerator gracePeriod(){
        yield return new WaitForSecondsRealtime(1.5f);
        state = State.Idle;
        Debug.Log("Player exit damage sector");
    }
}

// TODO create a abstract class of states?
