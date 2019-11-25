using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Shot : Bullet
{
    public sealed override void Move()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;

        if (transform.position.z >= maxZ)
        {
            Destroy(gameObject);
        }
    }
}
