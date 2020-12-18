using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyExplode : MonoBehaviour
{
    public GameObject SpawnExplode;
    private void OnDestroy()
    {
        GameObject newBox = Instantiate(SpawnExplode);
        newBox.transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z);
    }
}
