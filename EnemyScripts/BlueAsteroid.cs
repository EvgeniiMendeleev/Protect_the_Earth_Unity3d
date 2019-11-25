using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BlueAsteroid : Asteroid
{
    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Shot")
        {
            DamageFromPlayer(ref obj, "VfxBrightSparks", 1f);
        }
    }
}
