using System;
using StateMachine;
using UnityEngine;
using UnityEngine.Events;

namespace Interactables {
    public class WeaponPickUp : MonoBehaviour {
        [SerializeField] private Weapon weapon;
        private enum Weapon {crowbar, handgun}
        
        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                switch (weapon) {
                    case Weapon.crowbar:
                        other.GetComponent<FSMWorkWithAnimation>().EquipCrowbar();
                        break;
                    case Weapon.handgun:
                        other.GetComponent<FSMWorkWithAnimation>().EquipGun();
                        break;
                }
                Destroy(gameObject);
            }
        }
    }
}
