using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCrowbarTest : MonoBehaviour {
    public bool KeyPress = false;
    public GameObject DeAndActivateGameObject;
    void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            KeyPress = !KeyPress;
            DeAndActivateGameObject.SetActive(KeyPress);
        }
    }
}
