using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Character_Controller : MonoBehaviour
{
    [SerializeField]
    [Range(-30f, 10f)]
    public float CharacterSFXVolume;
    //Character:
    [FMODUnity.EventRef]
    public string EnemyEvent = "event:/THESPLIT/CharacterSplit/EnemyScreechSplit/EnemyScreechSplit";
    FMOD.Studio.EventInstance EnemySFX;

    [FMODUnity.EventRef]
    public string FootStepEvent = "event:/THESPLIT/CharacterSplit/FootstepsSplit/FootstepsSplit";
    FMOD.Studio.EventInstance FootStepSFX;

    [FMODUnity.EventRef]
    public string PlayerHitEvent = "event:/THESPLIT/CharacterSplit/PlayerHitSplit/PlayerHitSplit";
    FMOD.Studio.EventInstance PlayerHitSFX;

    [FMODUnity.EventRef]
    public string ReviveEvent = "event:/THESPLIT/CharacterSplit/ReviveSplit/ReviveSplit";
    FMOD.Studio.EventInstance ReviveSFX;

    [FMODUnity.EventRef]
    public string PlayerVoiceEvent = "event:/THESPLIT/CharacterSplit/VoiceSplit/PlayerVoiceSplit";
    FMOD.Studio.EventInstance PlayerVoiceSFX;

    void Start()
    {
        CharacterSFXVolume = 0f;

        EnemySFX = FMODUnity.RuntimeManager.CreateInstance(EnemyEvent);
        FootStepSFX = FMODUnity.RuntimeManager.CreateInstance(FootStepEvent);
        PlayerHitSFX = FMODUnity.RuntimeManager.CreateInstance(PlayerHitEvent);
        ReviveSFX = FMODUnity.RuntimeManager.CreateInstance(ReviveEvent);
        PlayerVoiceSFX = FMODUnity.RuntimeManager.CreateInstance(PlayerVoiceEvent);

    }
    void Update()
    {
        EnemySFX.setVolume(DecibelToLinear(CharacterSFXVolume));
        FootStepSFX.setVolume(DecibelToLinear(CharacterSFXVolume));
        PlayerHitSFX.setVolume(DecibelToLinear(CharacterSFXVolume));
        ReviveSFX.setVolume(DecibelToLinear(CharacterSFXVolume));
        PlayerVoiceSFX.setVolume(DecibelToLinear(CharacterSFXVolume));
    }
    private float DecibelToLinear(float db)
    {
        float linear = Mathf.Pow(10.0f, db / 20f);
        return linear;
    }
    public void EnemySFXSet(bool setEnemySFX)
    {
        if (setEnemySFX)
        {
            EnemySFX = FMODUnity.RuntimeManager.CreateInstance(EnemyEvent);
            EnemySFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            EnemySFX.start();
        }
        else
        {
            EnemySFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void FootStepSFXSet(bool setFootStepSFX)
    {
        if (setFootStepSFX)
        {
            FootStepSFX = FMODUnity.RuntimeManager.CreateInstance(FootStepEvent);
            FootStepSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            FootStepSFX.start();
        }
        else
        {
            FootStepSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void PlayerHitSFXSet(bool setPlayerHitSFX)
    {
        if (setPlayerHitSFX)
        {
            PlayerHitSFX = FMODUnity.RuntimeManager.CreateInstance(PlayerHitEvent);
            PlayerHitSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            PlayerHitSFX.start();
        }
        else
        {
            PlayerHitSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void ReviveSFXSet(bool setReviveSFX)
    {
        if (setReviveSFX)
        {
            ReviveSFX = FMODUnity.RuntimeManager.CreateInstance(ReviveEvent);
            ReviveSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            ReviveSFX.start();
        }
        else
        {
            ReviveSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void PlayerVoiceSFXSet(bool setPlayerVoiceSFX)
    {
        if (setPlayerVoiceSFX)
        {
            PlayerVoiceSFX = FMODUnity.RuntimeManager.CreateInstance(PlayerVoiceEvent);
            PlayerVoiceSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            PlayerVoiceSFX.start();
        }
        else
        {
            PlayerVoiceSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}
