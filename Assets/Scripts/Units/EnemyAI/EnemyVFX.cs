using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVFX : MonoBehaviour
{
    public GameObject DamageBloodVFX;
    private Transform _parent;
    private void Start(){
        _parent = this.transform;
    }

    public void ShowAlienBloodVFX(){
        StartCoroutine(BloodVFX());
    }
    
    IEnumerator BloodVFX(){
        var instance = Instantiate(DamageBloodVFX, _parent.position, Quaternion.identity);
        instance.transform.SetParent(_parent);
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(instance);
    }
}
