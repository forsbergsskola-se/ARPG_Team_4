using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_BGM_Level_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetLeveAudio1(bool setLevel1)
    {
        var audioTest = FindObjectOfType<Audio_BGM_Controller>();
        audioTest.LevelAudioSet1(setLevel1);
        //Debug.Log("Trigger menu sound: " + menuActive);
    }
    private void SetLeveAudio2(bool setLevel2)
    {
        var audioTest = FindObjectOfType<Audio_BGM_Controller>();
        audioTest.LevelAudioSet2(setLevel2);
        //Debug.Log("Trigger menu sound: " + menuActive);
    }
    private void SetLeveAudio3(bool setLevel3)
    {
        var audioTest = FindObjectOfType<Audio_BGM_Controller>();
        audioTest.LevelAudioSet3(setLevel3);
        //Debug.Log("Trigger menu sound: " + menuActive);
    }
}
