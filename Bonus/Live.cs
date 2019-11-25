using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : Bonus
{
    public sealed override void Upgrade(PlayerController player)
    {
        Instantiate(Resources.Load<GameObject>("Effects/BonusEffect"), transform.position, Quaternion.identity);
        Destroy(gameObject);

        if (player.GetLives < 2)
        {
            player.SetLives = player.GetLives + 1;
        }
    }
}
