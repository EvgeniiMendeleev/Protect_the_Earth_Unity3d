using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Bonus
{
    public sealed override void Upgrade(PlayerController player)
    {
        Instantiate(Resources.Load<GameObject>("Effects/BonusEffect"), transform.position, Quaternion.identity);
        Destroy(gameObject);

        int numberOfShot = Random.Range(1, 5);

        GameObject bull = Resources.Load<GameObject>("Bonus/ShotsOfPlayer/Shot_" + numberOfShot);

        Debug.Log("Номер выстрела равен: " + numberOfShot);
        player.SetShot = bull;

        if ((bull.transform.childCount > 0) && (numberOfShot > 2))
        {
            player.SetDt = bull.transform.GetChild(0).GetComponent<Bullet>().GetDt;
        }
        else
        {
            player.SetDt = bull.GetComponent<Bullet>().GetDt;
        }
    }
}
