using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.SceneManagement;

public abstract class Wave : MonoBehaviour { }

public sealed class Spawn : MonoBehaviour
{
    [SerializeField] private List<Wave> alienWaves;
    [SerializeField] private float dt;
    [SerializeField] private int numOfWave = 0;

    private float startTimeAsteroids = -1.0f;
    private float dTAsteroids = -1.0f;
    private float startTime;
    void Start()
    {
        startTime = Time.time + dt;
    }

    void Update()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Trajectory");

        if (obj && obj.transform.childCount == 0) Destroy(obj);
        else if (GameObject.FindGameObjectsWithTag("Alien").Length == 0 && !GameObject.FindGameObjectWithTag("SpawnOfAsteroids") && obj) Destroy(obj);

        if (numOfWave > alienWaves.Count)
        {
            if (Time.time > startTime)
            {
                SceneManager.LoadScene(0);
            }
        }
        else if (numOfWave == alienWaves.Count)
        {
            int numAliens = GameObject.FindGameObjectsWithTag("Alien").Length;
            int spawnAsteroids = GameObject.FindGameObjectsWithTag("SpawnOfAsteroids").Length;

            if (numAliens != 0 || spawnAsteroids != 0)
            {
                startTime = Time.time + dt;
            }
            else 
            {
                numOfWave += 1;
            }
        }
        else
        {
            if (alienWaves[numOfWave] is WaveOfAliens)
            {
                int numAliens = GameObject.FindGameObjectsWithTag("Alien").Length;

                if (numAliens == 0 && GameObject.FindGameObjectsWithTag("SpawnOfAsteroids").Length == 0)
                {
                    if (Time.time > startTime)
                    {
                        WaveOfAliens wave = alienWaves[numOfWave] as WaveOfAliens;
                        GameObject Trajectory = Instantiate(wave.trajectory);

                        for (int i = 0; i < wave.aliens.Count; i++)
                        {
                            for (int j = 0; j < wave.aliens[i].count; j++)
                            {
                                int numbOfTrajectory = wave.aliens[i].numOfTrajectory[j];
                                GameObject alienShip = Instantiate(wave.aliens[i].prefab);

                                alienShip.GetComponent<MoveOnTrajectory>().SetMyPathCreator = wave.trajectory.transform.GetChild(numbOfTrajectory).GetComponent<PathCreator>();
                                alienShip.GetComponent<EnemyController>().SetTimeOfFirstShot = wave.aliens[i].timeOfFirstShoot[j];
                                alienShip.GetComponent<MoveOnTrajectory>().SetSpeed = wave.aliens[i].speedOfEachAlien[j];
                            }
                        }

                        numOfWave += 1;
                    }
                }
                else
                {
                    startTime = Time.time + dt;
                }
            }
            else if (alienWaves[numOfWave] is WaveOfAsteroids)
            {
                int spawnAsteroids = GameObject.FindGameObjectsWithTag("SpawnOfAsteroids").Length;

                if (spawnAsteroids == 0 && GameObject.FindGameObjectsWithTag("Alien").Length == 0)
                {
                    if (Time.time > startTime)
                    {
                        WaveOfAsteroids wave = alienWaves[numOfWave] as WaveOfAsteroids;
                        Vector3 posSpawn = new Vector3(wave.x0, wave.y0, wave.z0);

                        Instantiate(wave.spawnOfAsteroids, posSpawn, wave.spawnOfAsteroids.transform.rotation);
                        
                        dTAsteroids = wave.dt;
                        startTimeAsteroids = Time.time + dTAsteroids;
                    }
                }
                else 
                {
                    startTime = Time.time + dt;

                    if (startTimeAsteroids >= 0)
                    {
                        if (Time.time > startTimeAsteroids)
                        {
                            Destroy(GameObject.FindGameObjectWithTag("SpawnOfAsteroids"));
                            numOfWave += 1;
                        }
                    }
                }
            }
        }
    }
}