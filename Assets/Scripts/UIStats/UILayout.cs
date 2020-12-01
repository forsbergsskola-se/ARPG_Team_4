using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIStatsResources {
    public class UILayout : MonoBehaviour
    {
        public Text UIStatAmount;
        public Text UIStatName;
        public UIStatsResource uiStatsResource;

        public void Update()
        {
            this.UIStatAmount.text = this.uiStatsResource.CurrentUIStats.ToString();
            this.UIStatName.text = this.uiStatsResource.name;
            this.UIStatAmount.color = this.uiStatsResource.color;
            this.UIStatName.color = this.uiStatsResource.color;
        }
        public void Setup(UIStatsResource uiStatsResource) {
            this.uiStatsResource = uiStatsResource;
        }
    }
}
