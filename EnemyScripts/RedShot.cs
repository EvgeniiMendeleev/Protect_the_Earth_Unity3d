using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class RedShot : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    private Vector3 posPlayer;
    private Vector3 newVelocity;

    void Start()
    {
        posPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
        newVelocity = new Vector3(posPlayer.x - transform.position.x, posPlayer.y - transform.position.y, posPlayer.z - transform.position.z);
        transform.LookAt(posPlayer);

        GetComponent<AudioSource>().Play();
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = newVelocity.normalized * speed;

        if (transform.position.z < minZ || transform.position.z >= maxZ || transform.position.x < minX || transform.position.x >= maxX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
