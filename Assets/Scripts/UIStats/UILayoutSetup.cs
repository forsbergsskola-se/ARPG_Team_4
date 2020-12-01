using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIStatsResources 
{ 
    public class UILayoutSetup : MonoBehaviour
    {
        public UIStatsResource[] uiStatResource;
        public UILayout prefab;
        void Start()
        {
            foreach (var uiStatResource in this.uiStatResource) 
            {
                var instance = Instantiate(this.prefab, this.transform);
                instance.Setup(uiStatResource);
            }
        }
    }
}
