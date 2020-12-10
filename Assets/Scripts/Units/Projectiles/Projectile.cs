using System;
using Units;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float maxDistance = 30.0f;
    public int Damage { get; set; }
    private Vector3 _startPoint;

    private void Start() {
        _startPoint = transform.position;
    }

    private void Update() {
        if ((transform.position - _startPoint).magnitude > maxDistance) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        //Check if target can be damaged
        IDamagable target = other.gameObject.GetComponent<IDamagable>();
        if (target != null) {
            Debug.Log("hit damagable");
            target.TakeDamage(Damage);
        }
        
        // projectile has collided with something and should be destroyed.
        Destroy(gameObject);
    }
}