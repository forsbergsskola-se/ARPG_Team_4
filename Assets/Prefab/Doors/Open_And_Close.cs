using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_And_Close : MonoBehaviour
{
    
    public GameObject Player;
    public float Max_distance_enter = 4;
    public bool IsOpen = true;
    
    private Animator _triggerAnimation;
    private float _distance = 0;
    protected const string DoorIsOpenAnim = "doorIsOpen";

    private void Start()
    {
        _triggerAnimation = GetComponent<Animator>();
    }
    public void Update()
    {
        _distance = Vector3.Distance (transform.position, Player.transform.position);
        
        if (_distance < Max_distance_enter) _triggerAnimation.SetBool(DoorIsOpenAnim, IsOpen = true);
        else _triggerAnimation.SetBool(DoorIsOpenAnim, IsOpen = false);
    }    
    
}
