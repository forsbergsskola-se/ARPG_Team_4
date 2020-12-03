using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIStatsResources {
    public class PlayerStatCalculator : MonoBehaviour 
    {
        public UIStatsResource resourceStat;
        int playerHealth;

        void Start()
        {
            playerHealth = this.resourceStat.StatAmount;
        }
    }
}
