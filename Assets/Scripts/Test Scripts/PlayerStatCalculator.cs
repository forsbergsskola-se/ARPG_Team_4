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
            playerHealth = this.resourceStat.CurrentUIStats;
            Debug.Log("Start "+ playerHealth);
        }
        private void Update()
        {
            if (playerHealth >= this.resourceStat.StatMaxAmount)
            {
                this.playerHealth = this.resourceStat.StatMaxAmount;
            }
            Debug.Log("Updated "+ playerHealth);
        }
    }
}
