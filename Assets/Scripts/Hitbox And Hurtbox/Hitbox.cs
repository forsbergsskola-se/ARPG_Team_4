using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Assets.Scripts.Hitbox_And_Hurtbox {
    public class Hitbox : MonoBehaviour {
        public int LifeSec;
        public int Damage;
        public string Effect = "Knockback";
        public int Knockback;
        public bool DeactivateOnImpact;
        public GameObject Parent;
        private float _lifeTimer;

        public void HasCollided() {
            if (DeactivateOnImpact) gameObject.SetActive(false);
        }

        private void OnEnable() {
            _lifeTimer = LifeSec;
        }

        private void Update() {
            _lifeTimer -= Time.deltaTime;
            if (_lifeTimer <= 0.0f) gameObject.SetActive(false);
        }
    }
}
