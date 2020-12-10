﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Units.Player {
    public class PlayerHealth : MonoBehaviour, IDamagable {
        public HealthScriptableObject healthScriptableObject;
        public UnityEvent GetDamaged;
        [Tooltip("the duration the player is invulnerable from damage on revival")]
        [SerializeField] private float _invulnerabilityDuration = 5f;
        private bool _invulnerable = false;

        public void TakeDamage(int damage) {
            
            //Player can be invulnerable to damage
            if (_invulnerable)
                return;
            
            healthScriptableObject.CurrentHealth -= damage;
            GetDamaged.Invoke();
            StartCoroutine(DamageFeedback());
        }
        
        IEnumerator DamageFeedback() {
            var playerMesh = GetComponent<MeshRenderer>();
            playerMesh.enabled = false;
            yield return new WaitForSeconds(0.2f);
            playerMesh.enabled = true;
            yield return null;
        }
        
        public void GainHealth(int healValue) {
            healthScriptableObject.CurrentHealth += healValue;
        }

        public void TriggerInvulnerability() {
            _invulnerable = true;
            Debug.Log("Player invulnerable: " + _invulnerable);
            StartCoroutine(InvulnerabilityTimer());
        }

        // Deactivates invulnerable after duration.
        private IEnumerator InvulnerabilityTimer() {
            yield return new WaitForSeconds(_invulnerabilityDuration);
            _invulnerable = false;
            Debug.Log("Player invulnerable: " + _invulnerable);
        }

        // private IEnumerator FlashObject(MeshRenderer toFlash, Color originalColor, Color flashColor, float flashTime, float flashSpeed) {
        //     var flashingFor = 0;
        //     var newColor = flashColor;
        //         while(flashingFor < flashTime)
        //     {
        //         toFlash.color = newColor;
        //         flashingFor += Time.deltaTime;
        //         yield return new WaitForSecons(flashSpeed);
        //         flashingFor += flashSpeed;
        //         if(newColor == flashColor)
        //         {
        //             newColor = originalColor;
        //         }
        //         else
        //         {
        //             newColor = flashColor;
        //         }
        //     }
        // }
        
    }
}
