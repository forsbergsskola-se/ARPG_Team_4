using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Assets.Scripts.Hitbox_And_Hurtbox {
    public class Hitbox : MonoBehaviour {
        public int LifeSec;
        public int Damage;
        public int Knockback;
        public bool DeactivateOnImpact;
        public GameObject Parent;
        private float _lifeTimer;

        public void HasCollided() {
            Debug.Log("Has Collided");
            if (DeactivateOnImpact) gameObject.SetActive(false);
        }

        private void OnEnable() {
            _lifeTimer = LifeSec;
            //Debug.Log(_lifeTimer);
        }

        private void Update() {
            //Debug.Log(_lifeTimer);
            _lifeTimer -= Time.deltaTime;
            if (_lifeTimer <= 0.0f) gameObject.SetActive(false);
        }
    }
}
