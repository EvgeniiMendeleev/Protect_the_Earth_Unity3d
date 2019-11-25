using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SpawnOfAsteroids : MonoBehaviour
{
    [SerializeField] private List<Asteroid> asteroids;
    [SerializeField] private float dt;
    private float startTime;

    void Start()
    {
        startTime = Time.time + dt;
    }
    
    void FixedUpdate()
    {
        if (Time.time > startTime)
        {
            float newX = Random.Range(transform.position.x - GetComponent<BoxCollider>().size.x / 2.0f, transform.position.x + GetComponent<BoxCollider>().size.x / 2.0f);
            Vector3 positionInCollider = new Vector3(newX, transform.position.y, transform.position.z);

            int numberOfAsteroid = Random.Range(0, asteroids.Count);

            Instantiate(asteroids[numberOfAsteroid], positionInCollider, asteroids[numberOfAsteroid].transform.rotation);
            
            startTime = Time.time + dt;
        }
    }
}
