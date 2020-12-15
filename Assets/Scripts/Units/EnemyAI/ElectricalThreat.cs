using UnityEngine;

namespace Units.EnemyAI{
    public class ElectricalThreat : MonoBehaviour {
        [SerializeField] private int damage = 1;
        [SerializeField] private float ticsPerSecond = 2f;
        [SerializeField] private float radius = 2;
        [SerializeField] private LayerMask unitLayers;
        private float _nextTicTime;
        private bool currentFlowOn;

        private void Update() {
            if (Time.time < _nextTicTime)
                return;
            if (currentFlowOn){
                DealDamage();
                _nextTicTime = Time.time + 1f / ticsPerSecond;
            }
        }

        private void DealDamage() {
            //TODO explore OverlapBox option
            Collider[] unitsHit = Physics.OverlapSphere(transform.position, radius, unitLayers);

            foreach (var unit in unitsHit) {
                unit.GetComponent<IDamagable>().TakeDamage(damage);
            }
        }

        public void Damage(){
            currentFlowOn = true;
        }

        public void DontDamage(){
            currentFlowOn = false;
        }

        private void OnDrawGizmosSelected() {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}