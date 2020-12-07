using System;
using Assets.Scripts.Hitbox_And_Hurtbox;
using UnityEngine;

public class BasicHurtbox : MonoBehaviour {
    /*private const string HitBoxTag = "IsHitBox";
    public GameObject Parent;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == HitBoxTag) {
            var thisHealthScript = this.GetComponent<BasicObjectHealth>();
            var otherHitBoxScript = other.gameObject.GetComponent<BasicHitbox>();
            
            if (otherHitBoxScript.Parent == this.Parent) return;
            Debug.Log("damage " + otherHitBoxScript.Damage);
            thisHealthScript.UpdateHealth(otherHitBoxScript.Damage);
            otherHitBoxScript.HasCollided();
        }
    }*/
}
