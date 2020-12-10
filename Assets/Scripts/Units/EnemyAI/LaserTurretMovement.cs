using UnityEngine;

public class LaserTurretMovement : MonoBehaviour {
    private Vector3 _startPos;
    public float movementSpeed = 1f;
    public float patrolDistance = 5f;
    private float _moveSpeed;
    private bool _forward;
    private void Awake() {
        _startPos = transform.position;
        _moveSpeed = movementSpeed;
    }

    private void FixedUpdate() {
        if ((transform.position - _startPos).magnitude > patrolDistance)
            _forward = false;
        else if ((transform.position - _startPos).magnitude < 0.1f)
            _forward = true;
        
        _moveSpeed = _forward ? movementSpeed : -movementSpeed;
        transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
    }
}
