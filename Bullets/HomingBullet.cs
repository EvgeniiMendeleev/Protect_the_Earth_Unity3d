using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    private Transform positionOfEnemy;

    public sealed override void Move()
    {
        if (positionOfEnemy)
        {
            transform.LookAt(positionOfEnemy);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
        }
    }

    public void setClosetEnemy(Transform enemy)
    {
        if (enemy)
        {
            positionOfEnemy = enemy;
        }
    }
}
