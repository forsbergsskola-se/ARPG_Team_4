using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    /*
    FMOD.Studio.EventInstance ambience;
    public Transform TestHitBox;
    public LayerMask Layer;
    */
    public int ButtonPress = 0;
    void Start()
    {
        //ambience = FMODUnity.RuntimeManager.CreateInstance("event:/Ambiences/Ambiences");
        //ambience.start();
        ButtonPress = 0;
    }
    void Update()
    {
        if(ButtonPress >= 1)
        {
            SoundTest();
            ButtonPress -= 1;
        }
        
    }
    void SoundTest() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Button/Buttons", GetComponent<Transform>().position);
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
}
