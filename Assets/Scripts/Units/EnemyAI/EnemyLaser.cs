using Units;
using Units.Player;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class EnemyLaser : MonoBehaviour {
    private LineRenderer _lineRenderer;
    public float lengthOfLineRenderer = 20.0f;
    private float _moveSpeed;
    public int damage = 1;
    public float knockbackVelocity = 5f;
    public LayerMask hittableLayers;

    void Start() {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
        // patrolDistance = Mathf.Clamp(patrolDistance, 0, 1000);
        // transform.rotation = Quaternion.Euler(0, 0, 0);
        // _startPosX = transform.position.x;
        // _maxPosX = _startPosX + patrolDistance;
        // _moveSpeed = movementSpeed;
    }
    
    private void FixedUpdate() {
        // Flips direction bool when start and max positions are reached
        // if (transform.position.x > _maxPosX)
        //     _forward = false;
        // else if (transform.position.x < _startPosX)
        //     _forward = true;
        
        // Sets movement speed to positive or negative depending on bool
        // _moveSpeed = _forward ? movementSpeed : -movementSpeed;
        // transform.Translate(new Vector3(_moveSpeed, 0f, 0f));

        RaycastHit hit;
        Vector3 hitPosition;
        Vector3 currentPosition = transform.position;
        
        // raycast hit something
        if (Physics.Raycast(currentPosition, transform.TransformDirection(Vector3.forward), out hit, lengthOfLineRenderer, hittableLayers))
        {
            hitPosition = hit.point;
            var targetGameObject = hit.collider.gameObject;
            IDamagable targetDamagable = targetGameObject.GetComponent<IDamagable>();
            if (targetDamagable != null) {
                targetDamagable.TakeDamage(damage);
                
                // if the target is a player -> knockback
                if (targetGameObject.CompareTag("Player")) {
                    // constrain knockback to x,z axis
                    Vector3 knockbackDir = new Vector3 (
                        targetGameObject.transform.position.x - hitPosition.x, 
                        0.0f, 
                        targetGameObject.transform.position.z - hitPosition.z).normalized;

                    // knockback
                    targetGameObject.GetComponent<ClickToMove>().Knockback(knockbackDir * knockbackVelocity);
                }
            }
                
        }
        // raycast did not hit anything
        else
        {
            //Debug.DrawRay(currentPosition, transform.TransformDirection(Vector3.forward) * lengthOfLineRenderer, Color.white);
            hitPosition = currentPosition + transform.forward * lengthOfLineRenderer;;
        }
        
        // Set the liner renderer start and end points
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, hitPosition); 
    }
}
