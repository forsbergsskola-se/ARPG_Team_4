using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_SFX_Controller : MonoBehaviour
{
    [SerializeField]
    [Range(-30f, 10f)]
    public float SFXVolume = 0f; //Default
    //SFX:
    [FMODUnity.EventRef]
    public string BlowtorchEvent = "event:/THESPLIT/SFXSplit/BlowtorchSplit/BlowtorchSplit";
    FMOD.Studio.EventInstance BlowtorchSFX;

    [FMODUnity.EventRef]
    public string Button_1_Event = "event:/THESPLIT/SFXSplit/ButtonSplit/ButtonsSplit_1";
    FMOD.Studio.EventInstance Button_1_SFX;

    [FMODUnity.EventRef]
    public string Button_2_Event = "event:/THESPLIT/SFXSplit/ButtonSplit/ButtonsSplit_2";
    FMOD.Studio.EventInstance Button_2_SFX;

    [FMODUnity.EventRef]
    public string FlashlightOFF_Event = "event:/THESPLIT/SFXSplit/FlashlightSplit/FlashlightOFFSplit";
    FMOD.Studio.EventInstance FlashlightOFF_SFX;

    [FMODUnity.EventRef]
    public string FlashlightON_Event = "event:/THESPLIT/SFXSplit/FlashlightSplit/FlashlightONSplit";
    FMOD.Studio.EventInstance FlashlightON_SFX;

    [FMODUnity.EventRef]
    public string CratesEvent = "event:/THESPLIT/SFXSplit/ObjectsSplit/CratesSplit";
    FMOD.Studio.EventInstance CratesSFX;

    [FMODUnity.EventRef]
    public string PortalTransitionEvent = "event:/THESPLIT/SFXSplit/PortalSplit/Portal_transitionSplit";
    FMOD.Studio.EventInstance PortalTransitionSFX;

    [FMODUnity.EventRef]
    public string HazerdTrapEvent = "event:/THESPLIT/SFXSplit/TrapsSplit/HazardTrapSplit";
    FMOD.Studio.EventInstance HazerdTrapSFX;

    [FMODUnity.EventRef]
    public string LaserTrapEvent = "event:/THESPLIT/SFXSplit/TrapsSplit/LaserTrapSplit";
    FMOD.Studio.EventInstance LaserTrapSFX;

    void Start()
    {
        //SFXVolume = 0f;

        BlowtorchSFX = FMODUnity.RuntimeManager.CreateInstance(BlowtorchEvent);
        Button_1_SFX = FMODUnity.RuntimeManager.CreateInstance(Button_1_Event);
        Button_2_SFX = FMODUnity.RuntimeManager.CreateInstance(Button_2_Event);
        FlashlightOFF_SFX = FMODUnity.RuntimeManager.CreateInstance(FlashlightOFF_Event);
        FlashlightON_SFX = FMODUnity.RuntimeManager.CreateInstance(FlashlightON_Event);
        CratesSFX = FMODUnity.RuntimeManager.CreateInstance(CratesEvent);
        PortalTransitionSFX = FMODUnity.RuntimeManager.CreateInstance(PortalTransitionEvent);
        HazerdTrapSFX = FMODUnity.RuntimeManager.CreateInstance(HazerdTrapEvent);
        LaserTrapSFX = FMODUnity.RuntimeManager.CreateInstance(LaserTrapEvent);

    }
    void Update()
    {
        BlowtorchSFX.setVolume(DecibelToLinear(SFXVolume));
        Button_1_SFX.setVolume(DecibelToLinear(SFXVolume));
        Button_2_SFX.setVolume(DecibelToLinear(SFXVolume));
        FlashlightOFF_SFX.setVolume(DecibelToLinear(SFXVolume));
        FlashlightON_SFX.setVolume(DecibelToLinear(SFXVolume));
        CratesSFX.setVolume(DecibelToLinear(SFXVolume));
        PortalTransitionSFX.setVolume(DecibelToLinear(SFXVolume));
        HazerdTrapSFX.setVolume(DecibelToLinear(SFXVolume));
        LaserTrapSFX.setVolume(DecibelToLinear(SFXVolume));
    }
    private float DecibelToLinear(float db)
    {
        float linear = Mathf.Pow(10.0f, db / 20f);
        return linear;
    }
    public void BlowtorchSFXSet(bool setBlowtorchSFX)
    {
        if (setBlowtorchSFX)
        {
            BlowtorchSFX = FMODUnity.RuntimeManager.CreateInstance(BlowtorchEvent);
            BlowtorchSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            BlowtorchSFX.start();
        }
        else
        {
            BlowtorchSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void Button_1_SFXSet(bool setButton_1_SFX)
    {
        if (setButton_1_SFX)
        {
            Button_1_SFX = FMODUnity.RuntimeManager.CreateInstance(Button_1_Event);
            Button_1_SFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            Button_1_SFX.start();
        }
        else
        {
            Button_1_SFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void Button_2_SFXSet(bool setButton_2_SFX)
    {
        if (setButton_2_SFX)
        {
            Button_2_SFX = FMODUnity.RuntimeManager.CreateInstance(Button_2_Event);
            Button_2_SFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            Button_2_SFX.start();
        }
        else
        {
            Button_2_SFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void FlashlightOFF_SFXSet(bool setFlashlightOFF_SFX)
    {
        if (setFlashlightOFF_SFX)
        {
            FlashlightOFF_SFX = FMODUnity.RuntimeManager.CreateInstance(FlashlightOFF_Event);
            FlashlightOFF_SFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            FlashlightOFF_SFX.start();
        }
        else
        {
            FlashlightOFF_SFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void FlashlightON_SFXSet(bool setFlashlightON_SFX)
    {
        if (setFlashlightON_SFX)
        {
            FlashlightON_SFX = FMODUnity.RuntimeManager.CreateInstance(FlashlightON_Event);
            FlashlightON_SFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            FlashlightON_SFX.start();
        }
        else
        {
            FlashlightON_SFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void CratesSFXSet(bool setCratesSFX)
    {
        if (setCratesSFX)
        {
            CratesSFX = FMODUnity.RuntimeManager.CreateInstance(CratesEvent);
            CratesSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            CratesSFX.start();
        }
        else
        {
            CratesSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void PortalTransitionSFXSet(bool setPortalTransitionSFX)
    {
        if (setPortalTransitionSFX)
        {
            PortalTransitionSFX = FMODUnity.RuntimeManager.CreateInstance(PortalTransitionEvent);
            PortalTransitionSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            PortalTransitionSFX.start();
        }
        else
        {
            PortalTransitionSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void HazerdTrapSFXSet(bool setHazerdTrapSFX)
    {
        if (setHazerdTrapSFX)
        {
            HazerdTrapSFX = FMODUnity.RuntimeManager.CreateInstance(HazerdTrapEvent);
            HazerdTrapSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            HazerdTrapSFX.start();
        }
        else
        {
            HazerdTrapSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void LaserTrapSFXSet(bool setLaserTrapSFX)
    {
        var LP = FindObjectOfType<Audio_Laser_Position>();
        var lPposition = LP.gameObject.transform.position;
        if (setLaserTrapSFX)
        {
            LaserTrapSFX = FMODUnity.RuntimeManager.CreateInstance(LaserTrapEvent);
            LaserTrapSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(lPposition));
            LaserTrapSFX.start();
        }
        else
        {
            LaserTrapSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}
