using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] protected float dt;
    [SerializeField] protected float speed;
    [SerializeField] protected float maxZ;
    [SerializeField] private AudioSource audio;

    public float GetDt { get { return dt; } }
    public float GetDamage { get { return damage; } }

    public void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    void FixedUpdate()
    {
        Move();

        if (transform.position.z >= maxZ)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Alien" || obj.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }

    public virtual void Move() {}
}
