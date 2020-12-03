using Assets.Scripts.Hitbox_And_Hurtbox;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
    private const string HitBoxTag = "IsHitBox";
    public GameObject Parent;

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == HitBoxTag) {
            var thisHealthScript = this.GetComponent<ObjectHealth>();
            var otherHitBoxScript = other.gameObject.GetComponent<Hitbox>();

            if (otherHitBoxScript.Parent == this.Parent) return;
   
            
            /*
             switch (Effect)
             {
             case "Poison":
                Parent.ApplyPoison(Damage, time);
                break;
            case "Burn":
                Parent.ApplyBurn(Damage, time);
                break;
            case "Knockback":
                Parent.Knockback(Damage, KnockbackAamount);
                break;
              }
             
            */
            otherHitBoxScript.HasCollided();
            thisHealthScript.UpdateHealth(otherHitBoxScript.Damage);
        }
    }
}

