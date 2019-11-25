using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ExplosiveOfRedAsteroid : MonoBehaviour
{
    private SphereCollider coll;

    void Start()
    {
        coll = GetComponent<SphereCollider>();
        Destroy(coll, 0.3f);
    }
}