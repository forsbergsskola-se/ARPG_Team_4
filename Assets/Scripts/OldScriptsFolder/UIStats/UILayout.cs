using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[Serializable] public class IntEvent : UnityEvent<int> { };
[Serializable] public class StringEvent : UnityEvent<string> { };
[Serializable] public class ColorEvent : UnityEvent<Color> { };

namespace UIStatsResources {
    public class UILayout : MonoBehaviour
    {
        public StringEvent StatAmountChange;
        public StringEvent StatNameChange;
        public ColorEvent StatColorChange;
        UIStatsResource statResource;

        public StringEvent MaxStatAmountChange;
        public ColorEvent MaxStatColorChange;

        public void Setup(UIStatsResource statResource)
        {
            this.statResource = statResource;
            this.statResource.StatChange.AddListener(OnStatChange);
            OnStatChange(this.statResource.CurrentUIStats);
            this.StatNameChange.Invoke(statResource.name);
            this.StatColorChange.Invoke(this.statResource.color);


        }
        
        public void MaxSetup(UIStatsResource maxStatResource)
        {
            this.statResource = maxStatResource;
            this.statResource.MaxStatChange.AddListener(OnMaxStatChange);
            OnMaxStatChange(this.statResource.MaxUIStats);


        }
        
        public void OnStatChange(int value) {
            /*
            if (this.statResource.StatAmount >= this.statResource.StatMaxAmount) {
                this.StatAmountChange = this.MaxStatAmountChange;
            }
            */
            this.StatAmountChange.Invoke(value.ToString());
        }
        public void OnMaxStatChange(int value)
        {
            this.MaxStatAmountChange.Invoke(value.ToString());
        }

        /*
        public Text UIStatAmount;
        public Text UIStatMaxAmount;
        public Text UIStatName;
        public Text UIStatOutOf;
        public UIStatsResource uiStatsResource;
        

        public void Start()
        {
            
        }
        public void LateUpdate()
        {
            this.UIStatAmount.text = this.uiStatsResource.CurrentUIStats.ToString();
            this.UIStatName.text = this.uiStatsResource.name;
            this.UIStatAmount.color = this.uiStatsResource.color;
            this.UIStatName.color = this.uiStatsResource.color;
            this.UIStatMaxAmount.text = this.uiStatsResource.StatMaxAmount.ToString();
            this.UIStatMaxAmount.color = this.uiStatsResource.color;
            this.UIStatOutOf.color = this.uiStatsResource.color;
        }
        public void Setup(UIStatsResource uiStatsResource) {
            this.uiStatsResource = uiStatsResource;
        }
        */
    }
}
