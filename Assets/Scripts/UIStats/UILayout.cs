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

        public void Setup(UIStatsResource statResource)
        {
            this.statResource = statResource;
            this.statResource.StatChange.AddListener(OnStatChange);
            OnStatChange(this.statResource.CurrentUIStats);
            this.StatNameChange.Invoke(statResource.name);
            this.StatColorChange.Invoke(this.statResource.color);

        }
        public void OnStatChange(int value) {
            this.StatAmountChange.Invoke(value.ToString());
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
