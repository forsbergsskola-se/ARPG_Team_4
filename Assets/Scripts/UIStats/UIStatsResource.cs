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
        public int CurrentUIStats {
            get => PlayerPrefs.GetInt(this.name, this.StatAmount);
            set => PlayerPrefs.SetInt(this.name, value);
        }
        /*
        public void StatChange() { 
        }
        */
    }
}
