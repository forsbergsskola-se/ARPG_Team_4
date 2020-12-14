using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_And_Close : MonoBehaviour
{
    private Transform _playerTransform;
    public float Max_distance_enter = 4;
    public bool IsOpen = true;
    
    private Animator _triggerAnimation;
    private float _distance = 0;
    protected const string DoorIsOpenAnim = "doorIsOpen";

    private void Start()
    {
        _triggerAnimation = GetComponent<Animator>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (_playerTransform == null)
            Debug.LogError("There is no GameObject with the Player tag in the scene", this);
    }
    public void Update()
    {
        _distance = Vector3.Distance (transform.position, _playerTransform.position);
        
        if (_distance < Max_distance_enter) _triggerAnimation.SetBool(DoorIsOpenAnim, IsOpen = true);
        else _triggerAnimation.SetBool(DoorIsOpenAnim, IsOpen = false);
    }    
    
}
