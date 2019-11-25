using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PurpleAlien : EnemyController
{
    private Transform posPlayer;
    private Rigidbody AlienBody;
    private float startTime;
    private float nextShot;
    private uint countOfShot = 0;
    private float maxX;
    private float minX;
    [SerializeField] private float deviation; 
    [SerializeField] private float speed;
    [SerializeField] private float timeOfShot;
    [SerializeField] private float dShot;

    void Start()
    {
        AlienBody = GetComponent<Rigidbody>();
        posPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        startTime = Time.time + TimeOfFirstShot;
        nextShot = startTime + dShot;
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
        transform.LookAt(posPlayer);

        if (AlienBody.position.x <= minX || AlienBody.position.x >= maxX)
        {
            speed *= -1;
        }

        AlienBody.velocity = Vector3.right * speed;
    }

    public override sealed void Shot()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            if (Time.time > nextShot)
            {
                if (countOfShot < 3 && Time.time > timeOfShot)
                {
                    Instantiate(AlienShot, AlienGun.position, Quaternion.identity);
                    ++countOfShot;

                    timeOfShot = Time.time + dShot;
                }
                else if (countOfShot == 3)
                {
                    timeOfShot = nextShot = Time.time + dt;
                    countOfShot = 0;
                }
            }
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Shot")
        {
            DamageFrom(ref obj);
        }
        else if (obj.tag == "EndPoint")
        {
            GameObject MyTrajectory = gameObject.GetComponent<MoveOnTrajectory>().GetMyPathCreator.gameObject;
            GameObject Collision = obj.gameObject;

            if (Collision.transform.parent.name == MyTrajectory.name)
            {
                maxX = transform.position.x + deviation;
                minX = transform.position.x - deviation;

                Destroy(gameObject.GetComponent<MoveOnTrajectory>());
            }
        }
    }
}
