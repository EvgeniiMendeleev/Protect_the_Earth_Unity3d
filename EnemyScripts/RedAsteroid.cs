using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class RedAsteroid : Asteroid
{
    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Shot")
        {
            DamageFromPlayer(ref obj, "ExplosiveOfAsteroid", 2.3f);
        }
    }
}
