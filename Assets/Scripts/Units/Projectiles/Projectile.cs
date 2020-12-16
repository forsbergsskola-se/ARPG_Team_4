using UnityEngine;

namespace Units.Projectiles {
    public class Projectile : MonoBehaviour {
        private float _maxDistance = 30.0f;
        private int _damage;
        private Vector3 _startPoint;

        private void Start() {
            _startPoint = transform.position;
        }

        private void Update() {
            if ((transform.position - _startPoint).magnitude > _maxDistance) {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other) {
            IDamagable target = other.gameObject.GetComponent<IDamagable>();
            if(other.CompareTag("Player"))
            {
                return;
            }
            if (target != null && !other.CompareTag("Player")) {
                Debug.Log("projectile hit: " + other.gameObject.name);
                target.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }

        public void Setup(int damage, float velocity, float maxDistance, Vector3 direction) {
            _damage = damage;
            _maxDistance = maxDistance;
            GetComponent<Rigidbody>().velocity = velocity * direction;
            transform.LookAt(transform.position + direction);
        }
    }
}