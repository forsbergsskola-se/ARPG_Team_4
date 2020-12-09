using Units;
using Units.Player;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class EnemyLaser : MonoBehaviour {
    private LineRenderer _lineRenderer;
    public float lengthOfLineRenderer = 20.0f;
    public int damage = 1;
    public float knockbackVelocity = 5f;

    void Start()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
    }
    
    private void FixedUpdate() {
        
        RaycastHit hit;
        Vector3 hitPosition;
        Vector3 currentPosition = transform.position;
        
        // raycast hit something
        if (Physics.Raycast(currentPosition, transform.TransformDirection(Vector3.forward), out hit, lengthOfLineRenderer))
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
