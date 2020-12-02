using UnityEngine;

public class PlayerAttackTest : MonoBehaviour {
    public GameObject HitBox;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            HitBox.SetActive(true);
        }
    }
}
