using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyExplode : MonoBehaviour
{
    public GameObject SpawnExplode;
    private void OnDestroy()
    {
        Instantiate(SpawnExplode, transform);
    }
}
