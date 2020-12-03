using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIStatsResources
{
    [CreateAssetMenu]
    public class UIStatsResource : ScriptableObject
    {
        public Color color;
        public int StatAmount = 10;
        public int StatMaxAmount = 20;
        public int CurrentUIStats {
            get => PlayerPrefs.GetInt(this.name, this.StatAmount);
            set => PlayerPrefs.SetInt(this.name, value);
        }
        void Update() {
            if (StatMaxAmount <= StatAmount /*StatAmount >= StatMaxAmount*/) { 
                this.StatAmount = this.StatMaxAmount;
            }
        }
        /*
        public void StatChange() { 
        }
        */
    }
}
