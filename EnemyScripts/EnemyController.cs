using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    #region Variables
    [HideInInspector] protected float TimeOfFirstShot;
    [SerializeField] protected GameObject AlienShot;
    [SerializeField] protected Transform AlienGun;
    [SerializeField] protected float lives;
    [SerializeField] protected float dt;
    #endregion

    #region Virtual_Methods
    public virtual void Shot() {}
    public virtual void Move() {}
    #endregion

    #region Public_Methods
    public float GetTimeOfFirstShot { get { return TimeOfFirstShot; } }
    public float SetTimeOfFirstShot { set { TimeOfFirstShot = value; } }
    public void DamageFrom(ref Collider other)
    {
        lives -= other.GetComponent<Bullet>().GetDamage;

        if (lives > 0)
        {
            GameObject MiniExplosive = Resources.Load<GameObject>("Effects/VfxHitSparks");
            GameObject explosion = Instantiate(MiniExplosive, other.gameObject.transform.position, MiniExplosive.transform.rotation);

            Destroy(explosion, 0.8f);
        }
        else if (lives <= 0)
        {
            GameObject MegaExplosive = Resources.Load<GameObject>("Effects/ExplosiveOfEnemy");
            GameObject explosive = Instantiate(MegaExplosive, other.gameObject.transform.position, Quaternion.identity);

            BonusForPlayer();

            Destroy(gameObject);
            Destroy(explosive, 0.8f);
        }
    }

    public void BonusForPlayer()
    {
        int chance = 60;
        int rnd = Random.Range(0, 100);
        int numberOfBonus = Random.Range(1, 3);

        if (chance < rnd)
        {
            Instantiate(Resources.Load<GameObject>("Bonus/Bonus_" + numberOfBonus), transform.position, Quaternion.Euler(90, 0, 0));
        }
    }
    #endregion
}