using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class WaveOfAliens : Wave
{
    [System.Serializable] public struct Aliens
    {
        public GameObject prefab;
        public List<int> numOfTrajectory;
        public List<float> speedOfEachAlien;
        public List<int> timeOfFirstShoot;
        public int count;
    };

    public List<Aliens> aliens;
    public GameObject trajectory;
}
