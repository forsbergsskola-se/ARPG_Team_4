using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units.Player
{
    public class PlayerDisable : MonoBehaviour
    {
        /*
         * Can be called/check to dissable stuff
         * Be called from there to turn off inputs
         * bool funktion
         * 
         */

        public bool IsDisable = true;
        void Start()
        {

        }
        void Update()
        {
            if (!IsDisable)
            {
                Debug.Log("Is Enable");
                return;
            }
            else
            {
                Debug.Log("Is Disable");
            }
        }
    }
}   


