using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Enter values from user
    [SerializeField] private GameObject Shot;
    [SerializeField] private Transform FromShot;
    [SerializeField] private float dt = 0.02f;
    [SerializeField] private float SpeedShip;
    [SerializeField] private float lyambda;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    #endregion

    #region Variables
    private int lives = 1;
    private float newX, newY, newZ;
    private float nextShot;
    #endregion

    #region Public Methods
    public float SetDt { set { dt = value; } }
    public GameObject SetShot { set { Shot = value; }}
    public GameObject GetShot { get { return Shot; } }
    public int GetLives { get { return lives; } }
    public int SetLives { set { lives = value; } }
    #endregion
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Rigidbody PlayerBody = GetComponent<Rigidbody>();

        PlayerBody.velocity = new Vector3(moveX, 0, moveZ) * SpeedShip;

        newX = Mathf.Clamp(PlayerBody.position.x, minX, maxX);
        newZ = Mathf.Clamp(PlayerBody.position.z, minZ, maxZ);
        newY = PlayerBody.position.y;

        PlayerBody.position = new Vector3(newX, newY, newZ);
        PlayerBody.rotation = Quaternion.Euler(PlayerBody.velocity.z * lyambda, 0, -PlayerBody.velocity.x * lyambda);

        if (Time.time > nextShot)
        {
            nextShot = Time.time + dt;
            Instantiate(Shot, FromShot.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Bonus")
        {
            obj.GetComponent<Bonus>().Upgrade(this);
        }
        else if (obj.tag == "AlienShot" || obj.tag == "Alien")
        {
            if (--lives > 0)
            {
                GameObject explosiveOfPlayer = Instantiate(Resources.Load<GameObject>("Effects/MiniExplosivePlayer"), obj.transform.position, Quaternion.identity);
                Destroy(explosiveOfPlayer, 2.0f);
            }
            else
            {
                Instantiate(Resources.Load<GameObject>("Effects/MegaExplosive"), transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else if (obj.tag == "Explosive")
        {
            Instantiate(Resources.Load<GameObject>("Effects/MegaExplosive"), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (obj.tag == "Asteroid")
        {
            Destroy(obj.gameObject);
            Instantiate(Resources.Load<GameObject>("Effects/MegaExplosive"), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
