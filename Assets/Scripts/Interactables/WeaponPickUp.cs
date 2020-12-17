using StateMachine;
using UnityEngine;

namespace Interactables {
    public class WeaponPickUp : MonoBehaviour {

        [SerializeField] private bool crowbar;
        [SerializeField] private bool handgun;
        
        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                if (crowbar) 
                    other.GetComponent<FSMWorkWithAnimation>().EquipCrowbar();
                else if (handgun) 
                    other.GetComponent<FSMWorkWithAnimation>().EquipGun();
                
                Destroy(gameObject);
            }
        }
    }
}
