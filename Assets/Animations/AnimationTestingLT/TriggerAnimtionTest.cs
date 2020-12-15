using UnityEngine;

public class TriggerAnimtionTest : MonoBehaviour {
    private Animator _triggerAnimation;
    private bool _walkingButtonPressed;
    private bool _attackButtonPressed;
    private bool _tookDamage;
    private int _weaponEquipped = 1;

    private void Start() {
        _triggerAnimation = GetComponent<Animator>();
    }
    
    private void Update() {
        _walkingButtonPressed = Input.GetKey(KeyCode.Space);
        _attackButtonPressed = Input.GetKey(KeyCode.D);
        _tookDamage = Input.GetKeyDown(KeyCode.E);

        if (Input.GetKey(KeyCode.Alpha1)) _weaponEquipped = 1;
        else if (Input.GetKey(KeyCode.Alpha2)) _weaponEquipped = 2;
        else if (Input.GetKey(KeyCode.Alpha3)) _weaponEquipped = 3;
        
        _triggerAnimation.SetInteger("WeaponInHand", _weaponEquipped);
        _triggerAnimation.SetBool("IsWalking", _walkingButtonPressed);
        _triggerAnimation.SetBool("IsAttacking", _attackButtonPressed);
        _triggerAnimation.SetBool("PlayerTookDamage", _tookDamage);
    }
}
