using Assets.Scripts.Hitbox_And_Hurtbox;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
    private const string HitBoxTag = "IsHitBox";
    public GameObject Parent;

    private void OnTriggerStay(Collider other) {
        if (other.tag == HitBoxTag) {
            var thisHealthScript = this.GetComponent<ObjectHealth>();
            var otherHitBoxScript = other.gameObject.GetComponent<Hitbox>();

            if (otherHitBoxScript.Parent == this.Parent) return;

            thisHealthScript.UpdateHealth(otherHitBoxScript.Damage);
            otherHitBoxScript.HasCollided();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == HitBoxTag) {
            var thisHealthScript = this.GetComponent<ObjectHealth>();
            var otherHitBoxScript = other.gameObject.GetComponent<Hitbox>();

            if (otherHitBoxScript.Parent == this.Parent) return;

            switch (otherHitBoxScript.Effect) {
                case "Healing":
                    //thisHealthScript.ApplyHealing(Damage, time);
                    break;
                case "Poison":
                    //thisHealthScript.ApplyPoison(Damage, time);
                    break;
                case "Burn":
                    float[] Parameters = {2, 5};
                    thisHealthScript.InvokeEffect.Add("ApplyBurnEffect", Parameters);
                    break;
                case "Knockback":
                    thisHealthScript.UpdateHealth(otherHitBoxScript.Damage);
                    //thisHealthScript.Knockback(Damage, KnockbackAmount);
                    break;
                default:
                    thisHealthScript.UpdateHealth(otherHitBoxScript.Damage);
                    break;
            }
        }
    }
}

