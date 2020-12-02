using Assets.Scripts.Hitbox_And_Hurtbox;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
    private const string HitBoxTag = "IsHitBox";
    public GameObject Parent;
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Got here 1");
        
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == HitBoxTag) {
            var thisHealthScript = this.GetComponent<ObjectHealth>();
            var otherHitBoxScript = other.gameObject.GetComponent<Hitbox>();
            Debug.Log("Got here 2");
            if (otherHitBoxScript.Parent == this.Parent) return;
            Debug.Log("Got here 3");
            otherHitBoxScript.HasCollided();
            thisHealthScript.UpdateHealth(otherHitBoxScript.Damage);
        }
    }
}

