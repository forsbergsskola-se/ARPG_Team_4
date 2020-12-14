using Units.Player;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(MeleeAttack))]
[RequireComponent(typeof(ClickToMove))]
public class PlayerMouseInput : MonoBehaviour {
    [FormerlySerializedAs("targetLayers")] [SerializeField] private LayerMask walkableLayers;
    [SerializeField] private LayerMask enemyLayers;
    private GameObject _target;
    private UnityEngine.Camera _mainCamera;

    private MeleeAttack _meleeAttack;
    private ClickToMove _clickToMove;


    private void Start() {
        _mainCamera = UnityEngine.Camera.main;
        _meleeAttack = GetComponent<MeleeAttack>();
        _clickToMove = GetComponent<ClickToMove>();
    }

    private void Update() {
        Ray myRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        // Checks if mouse cursor is on an enemy
        if (Physics.Raycast(myRay, out hitInfo, 1000, enemyLayers)) {
            var target = hitInfo.collider.gameObject;
            
            // Updates mouse cursor if in range of enemy
            _meleeAttack.UpdateCursor(target.transform.position);
            
            // Checks if LMB is clicked this frame
            if (Input.GetMouseButtonDown(0)) {
                // if out of range, set destination 
                if (_meleeAttack.WithinAttackRange(target.transform.position)) {
                    _meleeAttack.TryAttack(target);
                    return;
                }
            }
        }
        else {
            // Sets mouse cursor to default
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        
        if (Physics.Raycast(myRay, out hitInfo, 1000, walkableLayers)) {
            // Checks if LMB is held down
            if (Input.GetMouseButton(0))
                _clickToMove.SetDestination(hitInfo.point);
        }
    }
}




// var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
// var overlay = Physics.OverlapSphere(mousePos, layerMasks);