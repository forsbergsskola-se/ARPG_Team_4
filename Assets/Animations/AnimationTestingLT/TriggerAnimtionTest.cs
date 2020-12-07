using UnityEngine;

public class TriggerAnimtionTest : MonoBehaviour {
    private Animator _triggerAnimation;
    private bool _walkingButtonPressed;
    private bool _punchButtonPressed;
    private bool _shootButtonPressed;

    private void Start() {
        _triggerAnimation = GetComponent<Animator>();
    }
    
    private void Update() {
        _walkingButtonPressed = Input.GetKey(KeyCode.Space);
        _punchButtonPressed = Input.GetKey(KeyCode.D);
        _shootButtonPressed = Input.GetKey(KeyCode.F);
        
        _triggerAnimation.SetBool("IsWalking", _walkingButtonPressed);
        _triggerAnimation.SetBool("HasPunched", _punchButtonPressed);
        _triggerAnimation.SetBool("IsShooting", _shootButtonPressed);
    }
}
