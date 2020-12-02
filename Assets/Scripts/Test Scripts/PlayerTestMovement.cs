using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMovement : MonoBehaviour
{
    public float acceleration;
    public float maxspeed;

    public Rigidbody rigidbody;
    public KeyCode[] inputkeys;
    private Vector3[] directionForKey;

    void Start()
    {
        directionForKey = new Vector3[] { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        for (int i = 0; i < inputkeys.Length; i++) {
            var key = inputkeys[i];

            if (Input.GetKey(key)) {
                Vector3 movment = directionForKey[i] * acceleration * Time.deltaTime;
                movePlayer(movment);
            }
        }
    }
    void movePlayer(Vector3 movement) {
        if (rigidbody.velocity.magnitude * acceleration > maxspeed)
        {
            rigidbody.AddForce(movement * -1);
        }
        else
        {
            rigidbody.AddForce(movement);
        }
    }
}
