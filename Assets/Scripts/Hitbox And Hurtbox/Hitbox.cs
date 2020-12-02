using UnityEngine;

namespace Assets.Scripts.Hitbox_And_Hurtbox {
    public class Hitbox : MonoBehaviour {
        public int Damage;
        public int LifeSec;
        public int Knockback;
        public bool DestroyOnImpact;
        public bool Collided = false;

        void HasCollided() {
            if (DestroyOnImpact && Collided) {
                isact
            }
        }
    }
}
