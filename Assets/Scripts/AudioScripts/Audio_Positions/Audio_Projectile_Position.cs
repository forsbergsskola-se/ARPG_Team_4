using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Projectile_Position : MonoBehaviour
{
    void Start()
    {
        ProjectileSound(true);
    }
    void Update()
    {
    }
    private void ProjectileSound(bool setHandGunSFX)
    {
        var AT = FindObjectOfType<Audio_Weapon_Controller>();
        AT.HandGunSet(setHandGunSFX);
    }
}
