using UnityEngine;

namespace Units.EnemyAI {
    public class StationaryThreat : MonoBehaviour {
        [SerializeField] private int damage = 1;
        [SerializeField] private float ticsPerSecond = 2f;
        [SerializeField] private float radius = 2;
        [SerializeField] private LayerMask unitLayers;
        private float _nextTicTime;

        [SerializeField] private float attackAudioPerSecond = 2.5f;
        private float _attackAudioPerSecond;
        private void Update() {
            if (Time.time < _nextTicTime)
                return;
        
            DealDamage();
            _nextTicTime = Time.time + 1f / ticsPerSecond;
        }

        private void DealDamage() {
            Collider[] unitsHit = Physics.OverlapSphere(transform.position, radius, unitLayers);

            foreach (var unit in unitsHit) {
                unit.GetComponent<IDamagable>().TakeDamage(damage);
            if (Time.time < _attackAudioPerSecond)
                return;
            EnemySound(true);
            _attackAudioPerSecond = Time.time + 1f / attackAudioPerSecond;
            }
        }

        private void OnDrawGizmosSelected() {
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        private void EnemySound(bool setEnemySFX)
        {
            var AT = FindObjectOfType<Audio_Character_Controller>();
            AT.EnemySFXSet(setEnemySFX);
        }
    }
}
