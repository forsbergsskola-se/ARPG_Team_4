using UnityEngine;
using UnityEngine.Serialization;

public class Open_And_Close : MonoBehaviour
{
    public bool IsOpen {
        get => _isOpen;
        set => _triggerAnimation.SetBool(DoorIsOpen, _isOpen = value);
    }

    public float maxDistanceEnter = 4;
    private float _distance = 0;
    private bool _isOpen;
    private const string DoorIsOpen = "doorIsOpen";
    private Transform _playerTransform;
    private Animator _triggerAnimation;

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
        
        if (_distance < maxDistanceEnter && !IsOpen) IsOpen = true;
        else if (_distance > maxDistanceEnter && IsOpen) IsOpen = false;
    }
}
