using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PlaySound: MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }
}
