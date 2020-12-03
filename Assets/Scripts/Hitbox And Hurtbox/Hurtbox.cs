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
            
             switch (otherHitBoxScript.Effect)
             {
             case "Healing":
                //Parent.ApplyHealing(Damage, time);
                break;
             case "Poison":
                //Parent.ApplyPoison(Damage, time);
                break;
            case "Burn":
                thisHealthScript.ApplyBurn(1, 0, other.gameObject);
                break;
            case "Knockback": 
                thisHealthScript.UpdateHealth(otherHitBoxScript.Damage);
                //Parent.Knockback(Damage, KnockbackAamount);
                break;
              }
             
            otherHitBoxScript.HasCollided();
        }
    }
}

