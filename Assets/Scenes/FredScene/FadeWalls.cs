using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWalls : MonoBehaviour{
    private UnityEngine.Camera mainCamera;
    public GameObject player;
    public GameObject wall;
    private Color _color;
    [Range(0.0f, 1.0f)]
    public float alphaValueSlider;
    RaycastHit hitInfo;
    private void Start(){
        _color = wall.GetComponent<MeshRenderer>().material.color;
        mainCamera = UnityEngine.Camera.main;
    }

    private void Update(){
        var dir = player.transform.position - mainCamera.transform.position;
        if (Physics.Raycast(mainCamera.transform.position, dir, out hitInfo, 1000)){
            if (hitInfo.collider.gameObject.CompareTag("Wall")){
                Debug.Log("Wall Was found");
                _color.a = alphaValueSlider;
                wall.GetComponent<MeshRenderer>().material.color = _color;
            }
            else{
                _color.a = 1;
                wall.GetComponent<MeshRenderer>().material.color = _color;
            }
        }
    }
}
