using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIStatsResources
{
    public class HealingZone : MonoBehaviour
    {
        public Transform healingZoneBoxPoint;
        public LayerMask healingTargetLayer;
        public UIStatsResource statType;

        void FixedUpdate()
        {
            HealEffect();
        }
        void HealEffect()
        {
            Collider[] healPlayer = Physics.OverlapBox(healingZoneBoxPoint.position, transform.localScale, Quaternion.identity, healingTargetLayer);
            //int i = 0;
            foreach (Collider heal in healPlayer)
            {
                Debug.Log("Player being healed");
            }
            // void OnDrawGizmosSelected() {
            //     if (healingZoneBoxPoint == null)
            //         return;
            //     Gizmos.DrawWireCube(healingZoneBoxPoint.position, transform.localScale);
            // }
        }
    }
}
