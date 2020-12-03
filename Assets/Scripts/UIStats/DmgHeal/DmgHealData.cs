using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIStatsResources.DmgHeal {
    [CreateAssetMenu(menuName = "DmgHeal/UIStatsResources/DmgHealData", fileName = "DmgHealData")]
    public class DmgHealData : ScriptableObject
    {
        [SerializeField] StatAmount HealAmount;
        [SerializeField] StatAmount DmgAmount;
        public float dmgHealInterval = 3f;

        public StatAmount GetStatHealAmount(int statAmount)
        {
            var result = this.HealAmount;
            return result;
        }
        public StatAmount GetStatDmgAmount(int statAmount)
        {
            var result = this.DmgAmount;
            return result;
        }
    }
}
