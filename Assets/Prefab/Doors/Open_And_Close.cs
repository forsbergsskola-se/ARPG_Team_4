using UnityEngine;
using UnityEngine.Serialization;

public class Open_And_Close : MonoBehaviour
{
    public GameObject player;
    public float maxDistanceEnter = 4;
    public bool IsOpen {
        get => _isOpen;
        set => _triggerAnimation.SetBool(DoorIsOpen, _isOpen = value);
    }
    private bool _isOpen;
    private const string DoorIsOpen = "doorIsOpen";
    private float _distance = 0;
    private Animator _triggerAnimation;

    private void Start()
    {
        _triggerAnimation = GetComponent<Animator>();
    }
    public void Update()
    {
        _distance = Vector3.Distance (transform.position, player.transform.position);
        
        if (_distance < maxDistanceEnter && !IsOpen) IsOpen = true;
        else if (_distance > maxDistanceEnter && IsOpen) IsOpen = false;
    }
}
