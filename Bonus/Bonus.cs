using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    protected Rigidbody body;
    [SerializeField] protected float speed;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        DestroyFromScene();
    }

    public void Move()
    {
        body.velocity = Vector3.back * speed;
    }
    public void DestroyFromScene()
    {
        if (transform.position.z < -520)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Upgrade(PlayerController player) { }
}