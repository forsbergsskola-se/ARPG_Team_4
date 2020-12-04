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
        public IntEvent StatChange;
        public IntEvent MaxStatChange;
        public int CurrentUIStats {
            get => PlayerPrefs.GetInt(this.name, this.StatAmount);
            set { 
                PlayerPrefs.SetInt(this.name, value);
                this.StatChange.Invoke(value);
            }
        }
        public int MaxUIStats{
            get => PlayerPrefs.GetInt(this.name + "Max Amount", this.StatMaxAmount);
            set
            {
                PlayerPrefs.SetInt(this.name + "Max Amount", value);
                this.MaxStatChange.Invoke(value);
            }
        }
    }
}
