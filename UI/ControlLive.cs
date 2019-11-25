using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlLive : MonoBehaviour
{
    private GameObject player;
    private bool closeTwo = true;
    private bool closeOne = false;
    private bool closeThree = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player)
        {
            int livesOfPlayer = player.GetComponent<PlayerController>().GetLives;

            if (livesOfPlayer == 2 && closeTwo)
            {
                transform.GetChild(1).GetComponent<RawImage>().texture = Resources.Load<Texture>("Images/LivePNG_cut-photo");
                closeOne = true;
                closeTwo = false;
            }
            else if (livesOfPlayer == 1 && closeOne)
            {
                transform.GetChild(1).GetComponent<RawImage>().texture = Resources.Load<Texture>("Images/mti3m");
                closeOne = false;
                closeTwo = true;
            }
        }
        else if(!player && closeThree)
        {
            transform.GetChild(0).GetComponent<RawImage>().texture = Resources.Load<Texture>("Images/mti3m");
            transform.GetChild(1).GetComponent<RawImage>().texture = Resources.Load<Texture>("Images/mti3m");
            closeThree = false;
        }
    }
}
