using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AlienShot : MonoBehaviour
{
    private AudioSource Sound;
    [SerializeField] private float SpeedOfShot;
    [SerializeField] private float maxZ;
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        Sound.Play();
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = Vector3.back * SpeedOfShot;

        if (transform.position.z < maxZ)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
