using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCloseEnemy : MonoBehaviour
{
    private Transform positionOfEnemy;
    private string[] namesOfEnemy = new string[] { "Alien", "Asteroid" };

    void Start()
    {
        foreach (string name in namesOfEnemy)
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag(name);

            if (enemys.Length > 0)
            {
                FindClose(ref enemys);
            }
        }

        GetComponent<HomingBullet>().setClosetEnemy(positionOfEnemy);
    }

    private void FindClose(ref GameObject[] enemys)
    {
        float length = Mathf.Sqrt(Mathf.Pow(enemys[0].transform.position.x - transform.position.x, 2) + Mathf.Pow(enemys[0].transform.position.z - transform.position.z, 2));
        positionOfEnemy = enemys[0].transform;

        for (int i = 1; i < enemys.Length; i++)
        {
            float newLength = Mathf.Sqrt(Mathf.Pow(enemys[i].transform.position.x - transform.position.x, 2) + Mathf.Pow(enemys[i].transform.position.z - transform.position.z, 2));

            if (length > newLength)
            {
                length = newLength;
                positionOfEnemy = enemys[i].transform;
            }
        }
    }
}
