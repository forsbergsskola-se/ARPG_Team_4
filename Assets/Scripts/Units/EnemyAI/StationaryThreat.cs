using UnityEngine;

namespace Units.EnemyAI {
    public class StationaryThreat : MonoBehaviour {
        [SerializeField] private int damage = 1;
        [SerializeField] private float ticsPerSecond = 2f;
        [SerializeField] private float radius = 2;
        [SerializeField] private LayerMask unitLayers;
        private float _nextTicTime;

        private void Update() {
            if (Time.time < _nextTicTime)
                return;
        
            DealDamage();
            _nextTicTime = Time.time + 1f / ticsPerSecond;
        }

        private void DealDamage() {
            //TODO explore OverlapBox option
            Collider[] unitsHit = Physics.OverlapSphere(transform.position, radius, unitLayers);

            foreach (var unit in unitsHit) {
                unit.GetComponent<IDamagable>().TakeDamage(damage);
            }
        }

        private void OnDrawGizmosSelected() {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
