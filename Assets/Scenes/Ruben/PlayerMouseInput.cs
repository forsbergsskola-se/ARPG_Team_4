using Units.Player;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(MeleeAttack))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerMouseInput : MonoBehaviour {
    [FormerlySerializedAs("targetLayers")] [SerializeField] private LayerMask walkableLayers;
    [SerializeField] private LayerMask enemyLayers;
    private GameObject _target;
    private UnityEngine.Camera _mainCamera;

    private MeleeAttack _meleeAttack;
    private PlayerMovement _playerMovement;


    private void Start() {
        _mainCamera = UnityEngine.Camera.main;
        _meleeAttack = GetComponent<MeleeAttack>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        Ray myRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        if (IsMouseCursorOnEnemy(myRay, out hitInfo)) {
            var target = hitInfo.collider.gameObject;
            
            _meleeAttack.UpdateCursor(target.transform.position);
            
            if (Input.GetMouseButtonDown(0)) {
                if (_meleeAttack.WithinAttackRange(target.transform.position)) {
                    _meleeAttack.TryAttack(target);
                    return;
                }
            }
        }
        else {
            SetDefaultCursor();
        }
        
        if (Physics.Raycast(myRay, out hitInfo, 1000, walkableLayers)) {
            if (Input.GetMouseButton(0))
                _playerMovement.SetDestination(hitInfo.point);
        }
    }

    private static void SetDefaultCursor() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private bool IsMouseCursorOnEnemy(Ray myRay, out RaycastHit hitInfo) {
        return Physics.Raycast(myRay, out hitInfo, 1000, enemyLayers);
    }
}




// var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
// var overlay = Physics.OverlapSphere(mousePos, layerMasks);