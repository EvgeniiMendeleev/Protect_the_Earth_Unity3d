using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DestroyOnTime : MonoBehaviour
{
    [SerializeField] private float t;
    void Start()
    {
        Destroy(gameObject, t);
    }
}
