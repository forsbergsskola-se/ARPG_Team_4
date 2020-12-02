using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDmgAoe : MonoBehaviour
{
    public Transform fireHitboxPoint;
    public float fireHitboxRange = 1.5f;
    public LayerMask fireLayers;

    void Update()
    {
        if () {
            FireAttack();
        }
    }
    void FireAttack() {
        Collider[] hitPlayer = Physics.OverlapBox(fireHitboxPoint.position, fireHitboxRange, fireLayers);
        int i = 0;
        foreach (Collider fire in hitPlayer) {
            Debug.Log("Player hit by Fire");
        }
    }
    void OnDrawGizmosSelected()
    {
        if (fireHitboxPoint == null)
            return;
        Gizmos.DrawWireSphere(fireHitboxPoint.position, fireHitboxRange);
    }
}
