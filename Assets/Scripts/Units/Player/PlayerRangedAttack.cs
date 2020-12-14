using Units.Player;
using UnityEngine;

/// <summary>
/// Fires a projectile on pressing "E"
/// </summary>
// TODO limited bullets.
// TODO art for bullet or other primitive? Make sure it is rotated correctly.
public class PlayerRangedAttack : MonoBehaviour
{
    // references
    public GameObject projectilePrefab = null;
    private UnityEngine.Camera _mainCamera;
    [Tooltip("The position where the projectile will be fired from")] public Transform firingPosition;
    public LayerMask whatCanBeClickedOn;
    private PlayerMovement _playerMovement;
    
    // parameters
    [SerializeField] private float projectileVelocity = 10f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float attacksPerSecond = 1f;
    [SerializeField] private KeyCode keyBind = KeyCode.E;
    
    // variables
    private bool _inputDisabled;
    private float _nextAttackTime;
    private float _attackTime;

    private void Start() {
        // get references
        _mainCamera = UnityEngine.Camera.main;
        _playerMovement = GetComponent<PlayerMovement>();
        
        // derive attack time
        _attackTime = 1f / attacksPerSecond;
    }

    void Update()
    {
        if (_inputDisabled)
            return;
        
        if (Time.time < _nextAttackTime) 
            return;

        if (Input.GetKeyDown(keyBind)) {
            FireProjectile();
            _nextAttackTime = Time.time + _attackTime;
        }
    }

    private void FireProjectile() {
        _playerMovement.ResetPath();

        Vector3 mousePos = GetMousePosition();
        transform.LookAt(mousePos);

        //instantiate projectile
        var projectileInstance = Instantiate(projectilePrefab, firingPosition.position, firingPosition.rotation);
        
        // set the projectile damage
        projectileInstance.GetComponent<Projectile>().Damage = damage;
        
        // set projectile velocity
        Vector3 transformPos = transform.position;
        Vector3 shootDir = new Vector3(mousePos.x - transformPos.x, 0.0f, mousePos.z - transformPos.z).normalized;
        projectileInstance.GetComponent<Rigidbody>().velocity = shootDir * projectileVelocity;
    }
    
    private Vector3 GetMousePosition() {
        Ray myRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Vector3 hitLocation = Vector3.zero;
        if (Physics.Raycast(myRay, out hitInfo, 1000, whatCanBeClickedOn)) {
            hitLocation = hitInfo.point;
        }

        return hitLocation;
    }
}