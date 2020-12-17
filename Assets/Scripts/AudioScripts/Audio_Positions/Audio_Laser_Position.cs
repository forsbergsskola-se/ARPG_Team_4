using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Laser_Position : MonoBehaviour
{
    void Start()
    {
        LaserSound(true);
    }
    void Update()
    {
    }
    private void LaserSound(bool setLaserTrapSFX)
    {
        var AT = FindObjectOfType<Audio_SFX_Controller>();
        AT.LaserTrapSFXSet(setLaserTrapSFX);
    }
}
