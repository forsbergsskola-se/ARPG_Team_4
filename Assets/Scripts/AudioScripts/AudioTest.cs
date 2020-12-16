using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public int MenuButtonPress = 0;
    public int MenuBGMSoundOn = 0;
    public int Menu = 0;
    public int MenuQuitButtonPress = 0;

    [FMODUnity.EventRef]
    public string MenuBGMEvent = "";
    FMOD.Studio.EventInstance MenuBGM;
    void Start()
    {
        MenuBGM = FMODUnity.RuntimeManager.CreateInstance(MenuBGMEvent);

        MenuBGMSoundOn = 0;
        MenuButtonPress = 0;
        MenuQuitButtonPress = 0;
    }
    void Update()
    {
    }
    public void MenuActive(bool menuIsActive)
    {
        if (menuIsActive)
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Stop();
            MenuBGM = FMODUnity.RuntimeManager.CreateInstance(MenuBGMEvent);
            MenuBGM.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            MenuBGM.start();
        }
        else
        {
            MenuBGM.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
    }
}

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
