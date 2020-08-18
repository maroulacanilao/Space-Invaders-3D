using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform Nozzle;
    public float RateOfFire = 1;
    public int scoreOnKill = 1;
    public int locationNum;
    public GameObject ExplosionVFX;
    public static AudioSource mAudioSource;
    public AudioClip EnemyShootSFX;

    int switchNumber;
    bool IsGoingForward;
    bool IsGoingRight;
    bool OnEdge;

    Stats mStats;

    void Start()
    {
        mStats = this.gameObject.GetComponent<Stats>();
        OnEdge = false;
        switchNumber = 0;
        mAudioSource = GetComponent<AudioSource>();
        StartCoroutine(ShootOnROF());
    }

    void Update()
    {
        EnemyMovemnt();

        //Debug//
        //if (Input.GetKey(KeyCode.K))
        //{
        //    Dies();

        //}
    }

    void EnemyShoot()
    {
        GameObject EnemyBullet = Instantiate(bulletPrefab, Nozzle.transform.position, transform.rotation);
        EnemyBullet.tag = "EnemyBullet";
        var EB = EnemyBullet.GetComponent<BulletMovement>();
        EB.damage = mStats.getWeaponDmg();
        EB.Owner = this.gameObject;

        AudioSource.PlayClipAtPoint(EnemyShootSFX, transform.position);

        Destroy(EnemyBullet, 5);
    }

    public void Dies()
    {
        PlayerUI.totalScore += scoreOnKill;

        float rng = Random.Range(0, 1.0f);
        if (rng > 0.60f)
        {
            GetComponentInParent<SpawnRandomPU>().Spawn();
        }

        var DVFX = Instantiate(ExplosionVFX, transform.position, transform.rotation);
        
        Destroy(DVFX.gameObject, DVFX.GetComponent<ParticleSystem>().main.duration);
        Destroy(this.gameObject);
    }

    void EnemyMovemnt()
    {
        float movement = mStats.getMovementSpeed() * Time.deltaTime;

        //Horizontal Movement//
        if (IsGoingRight == true) transform.Translate(movement, 0, 0);
        if (IsGoingRight == false) transform.Translate(-movement, 0, 0);



        //Z Movement//
        if (!OnEdge)
        {
            if (IsGoingForward) transform.Translate(0, 0, movement);
            if (!IsGoingForward) transform.Translate(0,0,0);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Wall.Trigger"))
        {
            IsGoingRight = !IsGoingRight;
            switchNumber++;

            if (switchNumber >= 10)
            {
                IsGoingForward = true;
                switchNumber = 0;
            }
        }

        if (collision.gameObject.CompareTag("ZTriggers"))
        {
            IsGoingForward = false;
        }

        if(collision.gameObject.CompareTag("ZEdge"))
        {
            OnEdge = true;
            IsGoingForward = false;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            mStats.SetCurrentHp(
                mStats.getCurrentHp()
                - collision.gameObject.GetComponent<BulletMovement>().damage);

            if (mStats.getCurrentHp() <= 0)
            {
                Dies();
            }
        }
    }

    IEnumerator ShootOnROF()
    {
        while(mStats.getCurrentHp()>0)
        {
            yield return new WaitForSeconds(RateOfFire);
            EnemyShoot();
        }
    }
}
