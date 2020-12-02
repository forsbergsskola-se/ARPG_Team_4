using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    public Transform myCamera;
    public Transform target;
    private Vector3 offset;

    void Awake() {
        offset = myCamera.position;
    }

    void Update() {
        myCamera.position = target.position + offset;
    }
}
