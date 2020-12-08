using System.Collections.Generic;
using Units;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class StationaryThreat : MonoBehaviour {
    public int damage = 1;
    public float _ticTime = .5f;
    private float _elapsedTime;
    
    // keep track of targets inside
    private List<IDamagable> _damagableList = new List<IDamagable>();
    
    private void Update() {
        if (_damagableList.Count > 0)
            DealDamage();
    }

    private void DealDamage() {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _ticTime) {
            _elapsedTime -= _ticTime;
            for (int i = 0; i < _damagableList.Count; i++) {
                if (_damagableList[i] == null) {
                    _damagableList.RemoveAt(i);
                    continue;
                }
                _damagableList[i].TakeDamage(damage);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        IDamagable target = other.transform.GetComponent<IDamagable>();
        if (target != null) {
            _damagableList.Add(target);
        }
    }

    private void OnTriggerExit(Collider other) {
        
        IDamagable target = other.transform.GetComponent<IDamagable>();
        if (target != null) {
            _damagableList.Remove(target);
        }
    }
}
