using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform Nozzle;
    public float RateOfFire = 1;
    bool  IsGoingRight = true;

    Stats mStats;

    void Start()
    {
        mStats = this.gameObject.GetComponent<Stats>();
        InvokeRepeating("EnemyShoot", 0, RateOfFire);
    }

    void Update()
    {
        float movement = mStats.getMovementSpeed() * Time.deltaTime;
        //if(IsGoingRight == true) transform.Translate(movement, 0, 0);
        //if (IsGoingRight == false) transform.Translate(-movement, 0, 0);

    }

    void EnemyShoot()
    {
        GameObject EnemyBullet = Instantiate(bulletPrefab, Nozzle.transform.position, transform.rotation) as GameObject;
        EnemyBullet.GetComponent<BulletMovement>().damage = mStats.getWeaponDmg();
        Destroy(EnemyBullet, 5);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Wall.Trigger"))
        {
            IsGoingRight = !IsGoingRight;
        }

    }

}
