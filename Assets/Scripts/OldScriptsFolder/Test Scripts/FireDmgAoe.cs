using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIStatsResources.DmgHeal{ 
public class FireDmgAoe : MonoBehaviour
{
    public Transform fireHitboxPoint;
    public float elapsedTime = 1.5f;
    public LayerMask fireLayers;
    public UIStatsResource statType;
    public DmgHealData data;

    void FixedUpdate()
    {
        FireAttack();
    }
        void FireAttack() {
            Collider[] hitPlayer = Physics.OverlapBox(fireHitboxPoint.position, transform.localScale, Quaternion.identity,  fireLayers);
            //int i = 0;
            foreach (Collider fire in hitPlayer) {
                DmgHealUpdate();
                //DmgHealProduce();
                //Debug.Log("Player hit by Fire");
        }
    }
        void DmgHealUpdate()
        {
            this.elapsedTime += Time.deltaTime;
            if (this.elapsedTime >= this.data.dmgHealInterval)
            {
                DmgHealProduce();
                Debug.Log("Player hit by Fire");
                this.elapsedTime -= this.data.dmgHealInterval;
            }
        }
        public int Amount
        {
            get => PlayerPrefs.GetInt(this.data.name, 0);
            private set => PlayerPrefs.SetInt(this.data.name, value);
        }
        void DmgHealProduce()
        {
            Debug.Log("Methord DmgHealProduce");
            var Heal = this.data.GetStatHealAmount(this.Amount);
            var DMG = this.data.GetStatDmgAmount(this.Amount);
            statType.CurrentUIStats -= DMG.statAmount;
            Debug.Log("" + statType.CurrentUIStats);
            if (this.Amount == 0)
                return;
        }
        void OnDrawGizmosSelected()
        {
            if (fireHitboxPoint == null)
                return;
            Gizmos.DrawWireCube(fireHitboxPoint.position, transform.localScale);
        }
    }
}
