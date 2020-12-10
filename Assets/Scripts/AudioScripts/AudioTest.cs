using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    FMOD.Studio.EventInstance ambience;
    public Transform TestHitBox;
    public LayerMask Layer;
    void Start()
    {
        ambience = FMODUnity.RuntimeManager.CreateInstance("event:/Ambiences/Ambiences");
        ambience.start();
    }
    void Update()
    {
        Collider[] hitPlayer = Physics.OverlapBox(TestHitBox.position, transform.localScale, Quaternion.identity, Layer);
        foreach (Collider I in hitPlayer)
        {
            SoundTest();
        }
    }

    void SoundTest() 
    { 
        ambience.setParameterByName("Ambience Fade", 0f); 
    }
        /*
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
