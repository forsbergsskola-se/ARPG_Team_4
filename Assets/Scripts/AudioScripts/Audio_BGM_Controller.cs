using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_BGM_Controller : MonoBehaviour
{

    [SerializeField]
    [Range(-30f, 10f)]
    public float BGMVolume = -10f; //Default.
    //Levels:
    [FMODUnity.EventRef]
    public string LevelBGMEvent1 = "event:/THESPLIT/AmbientSplit/Level1Split";
    FMOD.Studio.EventInstance LevelBGM1;

    [FMODUnity.EventRef]
    public string LevelBGMEvent2 = "event:/THESPLIT/AmbientSplit/Level2Split";
    FMOD.Studio.EventInstance LevelBGM2;

    [FMODUnity.EventRef]
    public string LevelBGMEvent3 = "event:/THESPLIT/AmbientSplit/Level 3Split";
    FMOD.Studio.EventInstance LevelBGM3;

    //Menus:
    [FMODUnity.EventRef]
    public string MenuBGMEvent = "event:/THESPLIT/AmbientSplit/MenuHUMSplit";
    FMOD.Studio.EventInstance MenuBGM;

    void Start()
    {
        //BGMVolume = -10f;

        MenuBGM = FMODUnity.RuntimeManager.CreateInstance(MenuBGMEvent);
        LevelBGM1 = FMODUnity.RuntimeManager.CreateInstance(LevelBGMEvent1);
        LevelBGM2 = FMODUnity.RuntimeManager.CreateInstance(LevelBGMEvent2);
        LevelBGM3 = FMODUnity.RuntimeManager.CreateInstance(LevelBGMEvent3);

    }
    void Update()
    {
        MenuBGM.setVolume(DecibelToLinear(BGMVolume));
        LevelBGM1.setVolume(DecibelToLinear(BGMVolume));
        LevelBGM2.setVolume(DecibelToLinear(BGMVolume));
        LevelBGM3.setVolume(DecibelToLinear(BGMVolume));
    }
    private float DecibelToLinear(float db)
    {
        float linear = Mathf.Pow(10.0f, db / 20f);
        return linear;
    }
    public void MenuActive(bool menuIsActive)
    {
        if (menuIsActive)
        {
            MenuBGM = FMODUnity.RuntimeManager.CreateInstance(MenuBGMEvent);
            MenuBGM.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            MenuBGM.start();
        }
        else
        {
            MenuBGM.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void LevelAudioSet1(bool setLevel1)
    {
        if (setLevel1)
        {
            LevelBGM1 = FMODUnity.RuntimeManager.CreateInstance(LevelBGMEvent1);
            LevelBGM1.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            LevelBGM1.start();
        }
        else
        {
            LevelBGM1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void LevelAudioSet2(bool setLevel2)
    {
        if (setLevel2)
        {
            LevelBGM2 = FMODUnity.RuntimeManager.CreateInstance(LevelBGMEvent2);
            LevelBGM2.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            LevelBGM2.start();
        }
        else
        {
            LevelBGM2.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    public void LevelAudioSet3(bool setLevel3)
    {
        if (setLevel3)
        {
            LevelBGM3 = FMODUnity.RuntimeManager.CreateInstance(LevelBGMEvent3);
            LevelBGM3.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            LevelBGM3.start();
        }
        else
        {
            LevelBGM3.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}
/*
public int MenuButtonPress = 0;
public int MenuBGMSoundOn = 0;
public int Menu = 0;
public int MenuQuitButtonPress = 0;

    MenuBGMSoundOn = 0;
    MenuButtonPress = 0;
    MenuQuitButtonPress = 0;

        //GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        //GetComponent<FMODUnity.StudioEventEmitter>().Play();
*/

/*
void MenuButtonSound() 
{

    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Button/Buttons", GetComponent<Transform>().position);

FMOD.Studio.EventInstance ambience;
public Transform TestHitBox;
public LayerMask Layer;


    var MenuBGM = FMODUnity.RuntimeManager.CreateInstance(MenuBGMEvent);
    ambience = FMODUnity.RuntimeManager.CreateInstance("event:/Ambiences/Ambiences");
    ambience.start();

    if(MenuButtonPress >= 1)
    {
        MenuButtonSound();
        MenuButtonPress -= 1;
    }
    if(MenuBGMSoundOn >= 1)
    {
        //  Problem might be that it keep updating and calling the On for the BGM insted of just once need to be changed to once.
        Debug.Log("Menu BGM On");
        MenuBGMOn();
    }
    else if(MenuBGMSoundOn == 0)
    {
        Debug.Log("Menu BGM Off");
        MenuBGMOff();
    }
    if(MenuQuitButtonPress >= 1)
    {
        MenuQuit();
        MenuQuitButtonPress -= 1;
    }

    else if (MenuBGMSoundOn == 0)
    {
        MenuBGMOff();
    }

}
void MenuQuit()
{
    FMODUnity.RuntimeManager.PlayOneShot("event:/THESPLIT/SFXSplit/ButtonSplit/ButtonsSplit_2", GetComponent<Transform>().position);
}
void MenuBGMOn()
{
    FMODUnity.RuntimeManager.CreateInstance(MenuBGMEvent);
    //MenuBGM.start(FMODUnity.RuntimeManager.CreateInstance(MenuBGMEvent));
    FMODUnity.RuntimeManager.AttachInstanceToGameObject(MenuBGM, GetComponentInParent<Transform>(), GetComponentInParent<Rigidbody>());

    GetComponent<FMODUnity.StudioEventEmitter>().Play();
    //GetComponent<FMODUnity.StudioParameterTrigger>().TriggerParameters();

    /*
    var MenuBGM = FMODUnity.RuntimeManager.CreateInstance(MenuBGMEvent);
    MenuBGM.start();
    FMOD.Studio.EventInstance MenuBGM;
    MenuBGM = FMODUnity.RuntimeManager.CreateInstance("event:/THESPLIT/AmbientSplit/MenuHUMSplit");
    //GetComponent<FMODUnity.StudioEventEmitter>().Play();
    //FMODUnity.RuntimeManager.PlayOneShot("event:/THESPLIT/AmbientSplit/MenuHUMSplit", GetComponent<Transform>().position);

}
void MenuBGMOff()
{
    MenuBGM.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    GetComponent<FMODUnity.StudioEventEmitter>().Stop();


    /*
    var MenuBGM = FMODUnity.RuntimeManager.CreateInstance(MenuBGMEvent);
    MenuBGM.stopAllEvents(FMOD.Studio.STOP_MODE.IMMEDIATE);

    //GetComponent<FMODUnity.StudioEventEmitter>().Stop();

}
void MenuPauseAudio()
{
    FMODUnity.RuntimeManager.PlayOneShot("", GetComponent<Transform>().position);
}
    /*
    Collider[] hitPlayer = Physics.OverlapBox(TestHitBox.position, transform.localScale, Quaternion.identity, Layer);
    foreach (Collider I in hitPlayer)
    {
        SoundTest();
    }


[FMODUnity.EventRef]
public string inputsound;
bool playersMoving;
public float walkingSpeed;
    if(Input.GetAxis("Vertical") => 0.01f || Input.GetAxis("Horizontal") => 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f )
    {
        playersMoving = true;
    }
    else if (Input.GetAxis("Vertical") == 0f || Input.GetAxis("Horizontal") == 0f)
    {
        playersMoving = false;
    }
    */
