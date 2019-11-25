using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EndPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider Alien)
    {
        if (Alien.tag == "Alien")
        {
            GameObject MyTrajectory = Alien.GetComponent<MoveOnTrajectory>().GetMyPathCreator.gameObject;

            if (gameObject.transform.parent.name == MyTrajectory.name)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
