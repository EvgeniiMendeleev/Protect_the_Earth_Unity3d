using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class WhiteAlien : EnemyController
{
    private Rigidbody AlienBody;
    private float maxX = 0.0f, minX = 0.0f;
    private float deviation = 100.0f;
    private float startTime;
    private float nextShot;
    [SerializeField] private float speed;

    void Start()
    {
        startTime = Time.time + TimeOfFirstShot;
    }

    void FixedUpdate()
    {
        if (Time.time > startTime)
        {
            Move();
            Shot();
        }
    }

    public sealed override void Move()
    {
        Rigidbody AlienBody = GetComponent<Rigidbody>();

        if (AlienBody.position.x <= minX || AlienBody.position.x >= maxX)
        {
            speed *= -1;
        }

        AlienBody.velocity = Vector3.right * speed;
    }

    public sealed override void Shot()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            if (Time.time > nextShot)
            {
                nextShot = Time.time + dt;
                bool shot = System.Convert.ToBoolean(Random.Range(0, 2));

                if (shot)
                {
                    Instantiate(AlienShot, AlienGun.position, Quaternion.identity);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            GameObject MyTrajectory = gameObject.GetComponent<MoveOnTrajectory>().GetMyPathCreator.gameObject;
            GameObject Collision = other.gameObject;

            if (Collision.transform.parent.name == MyTrajectory.name)
            {
                maxX = transform.position.x + deviation;
                minX = transform.position.x - deviation;

                Destroy(gameObject.GetComponent<MoveOnTrajectory>());
            }
        }
        else if (other.tag == "Shot")
        {
            DamageFrom(ref other);
        }
    }
}
