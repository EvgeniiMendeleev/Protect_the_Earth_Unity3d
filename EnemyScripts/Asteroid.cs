using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Asteroid : MonoBehaviour
{
    [HideInInspector] protected uint lives = 7;
    [HideInInspector] protected float lyambda = 2;
    [HideInInspector] protected float speedOfAsteroid = 500;
    [HideInInspector] protected Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(1, 1, 1) * lyambda;
    }

    public void Move()
    {
        rb.velocity = new Vector3(0, 0, -1) * speedOfAsteroid;

        if (rb.position.z < -500)
        {
            Destroy(gameObject);
        }
    }

    public void DamageFromPlayer(ref Collider obj, string NameOfEffect, float time)
    {
        if (--lives <= 0)
        {
            GameObject explosion = Instantiate(Resources.Load<GameObject>("Effects/" + NameOfEffect), gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosion, time);
        }
        else
        {
            Instantiate(Resources.Load<GameObject>("Effects/MiniExplosive"), obj.transform.position, Quaternion.identity);
        }
    }
}
