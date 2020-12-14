using System;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

namespace Units.EnemyAI{
    public class ElectricalRandomThreat : MonoBehaviour
    {
        private float timer;
        private float randomTime;
        void Start(){
            randomTime = Random.Range(0.5f, 2.5f);
        }

        void Update(){
            timer += Time.deltaTime;
            if (timer > randomTime){
                GetComponent<VisualEffect>().Play();
                timer -= randomTime;
                randomTime = Random.Range(0.5f, 2.5f);
                SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
            }
            else{
                SendMessage("DontDamage", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}