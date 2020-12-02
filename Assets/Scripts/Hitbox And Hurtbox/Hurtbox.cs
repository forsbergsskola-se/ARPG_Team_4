using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Hitbox_And_Hurtbox;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
    public Collider HurtBox;
    private const string HitBoxTag = "IsHitBox";
    public int HitBoxBaseDamage;
    

    void OnCollisionEnter(Collision dataFromCollision) {
        if (dataFromCollision.gameObject.tag == HitBoxTag) {
            var objectHealthScript = GetComponent<ObjectHealth>();

            dataFromCollision.collided = true;
            HitBoxBaseDamage = dataFromCollision.transform.GetComponent<Hitbox>().Damage;
            objectHealthScript.Health -= HitBoxBaseDamage * objectHealthScript.HealthModifier;
            
        }
    }
}

