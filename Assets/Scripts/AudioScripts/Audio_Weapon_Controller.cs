using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Weapon_Controller : MonoBehaviour
{
    [SerializeField]
    [Range(-30f, 10f)]
    public float WeaponVolume = 0f; //Default
    //Weapon:
    [FMODUnity.EventRef]
    public string CrowbarEvent = "event:/THESPLIT/WeaponsSplit/Crowbar";
    FMOD.Studio.EventInstance CrowbarSFX;

    [FMODUnity.EventRef]
    public string HandGunEvent = "event:/THESPLIT/WeaponsSplit/HAndGun";
    FMOD.Studio.EventInstance HandGunSFX;
    /*
    [FMODUnity.EventRef]
    public string PlasmaEvent = "event:/THESPLIT/WeaponsSplit/Plasma";
    FMOD.Studio.EventInstance PlasmaSFX;

    [FMODUnity.EventRef]
    public string ShotgunEvent = "event:/THESPLIT/WeaponsSplit/Shotgun";
    FMOD.Studio.EventInstance ShotgunSFX;
    */
    void Start()
    {
        //WeaponVolume = 0f;

        CrowbarSFX = FMODUnity.RuntimeManager.CreateInstance(CrowbarEvent);
        HandGunSFX = FMODUnity.RuntimeManager.CreateInstance(HandGunEvent);
        //PlasmaSFX = FMODUnity.RuntimeManager.CreateInstance(PlasmaEvent);
        //ShotgunSFX = FMODUnity.RuntimeManager.CreateInstance(ShotgunEvent);

    }
    void Update()
    {
        CrowbarSFX.setVolume(DecibelToLinear(WeaponVolume));
        HandGunSFX.setVolume(DecibelToLinear(WeaponVolume));
        //PlasmaSFX.setVolume(DecibelToLinear(WeaponVolume));
        //ShotgunSFX.setVolume(DecibelToLinear(WeaponVolume));
    }
    private float DecibelToLinear(float db)
    {
        float linear = Mathf.Pow(10.0f, db / 20f);
        return linear;
    }
    public void CrowbarSet(bool setCrowbarSFX)
    {
        if (setCrowbarSFX)
        {
            CrowbarSFX = FMODUnity.RuntimeManager.CreateInstance(CrowbarEvent);
            CrowbarSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            CrowbarSFX.start();
        }
        else
        {
            CrowbarSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void HandGunSet(bool setHandGunSFX)
    {
        var HGP = FindObjectOfType<Audio_Projectile_Position>();
        var hGPposition = HGP.gameObject.transform.position;
        if (setHandGunSFX)
        {
            HandGunSFX = FMODUnity.RuntimeManager.CreateInstance(HandGunEvent);
            HandGunSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(hGPposition));
            HandGunSFX.start();
        }
        else
        {
            HandGunSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    /*
    public void PlasmaSet(bool setPlasmaSFX)
    {
        if (setPlasmaSFX)
        {
            PlasmaSFX = FMODUnity.RuntimeManager.CreateInstance(PlasmaEvent);
            PlasmaSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            PlasmaSFX.start();
        }
        else
        {
            PlasmaSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void LevelAudioSet3(bool setLevel3)
    {
        if (setLevel3)
        {
            ShotgunSFX = FMODUnity.RuntimeManager.CreateInstance(ShotgunEvent);
            ShotgunSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            ShotgunSFX.start();
        }
        else
        {
            ShotgunSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    */
}
