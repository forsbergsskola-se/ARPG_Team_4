using Assets.Scripts.Hitbox_And_Hurtbox;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
    private const string HitBoxTag = "IsHitBox";
    public GameObject Parent;
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != HitBoxTag) return;
        
        var thisHealthScript = this.GetComponent<ObjectHealth>();
        var otherHitBoxScript = other.gameObject.GetComponent<Hitbox>();
        
        if (otherHitBoxScript.Parent == this.Parent) return;
            
        otherHitBoxScript.HasCollided();
        thisHealthScript.UpdateHealth(otherHitBoxScript.Damage);
        
    }
}

