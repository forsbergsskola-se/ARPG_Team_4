using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVFX : MonoBehaviour{
    public GameObject HealthPickupSparksVFX;
    public GameObject HealthPickupGlowVFX;
    public GameObject DamageBloodVFX;
    private Transform _player;

    private void Start(){
        _player = this.transform;
    }

    public void ShowHealthVFX(){
        StartCoroutine(HealthVFX());
    }

    public void ShowBloodVFX(){
        StartCoroutine(BloodVFX());
    }
    public void ShowReviveVFX(){
        StartCoroutine(ReviveVFX());
    }

    IEnumerator HealthVFX(){
        var instanceSparks = Instantiate(HealthPickupSparksVFX, _player.position, Quaternion.identity);
        var instanceGlow = Instantiate(HealthPickupGlowVFX, _player.position, Quaternion.identity);
        instanceGlow.transform.SetParent(_player);
        instanceSparks.transform.SetParent(_player);
        yield return new WaitForSecondsRealtime(2.5f);
        Destroy(instanceSparks);
        Destroy(instanceGlow);
    }
    IEnumerator BloodVFX(){
        var instance = Instantiate(DamageBloodVFX, _player.position, Quaternion.identity);
        instance.transform.SetParent(_player);
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(instance);
    }

    IEnumerator ReviveVFX(){
        var instanceGlow = Instantiate(HealthPickupGlowVFX, _player.position, Quaternion.identity);
        instanceGlow.transform.SetParent(_player);
        yield return new WaitForSecondsRealtime(2.5f);
        Destroy(instanceGlow);
    }
}
