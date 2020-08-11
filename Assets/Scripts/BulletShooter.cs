using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletShooter : MonoBehaviour
{
    public Transform Nozzle;
    public GameObject BulletPrefab;
    public float timerDestroy = 5;
    public int MagazineSize = 10;

    int currentBulletCount;
    bool canFire = true;
    float reloadtime = 1;
    Stats mStats;

    public Text bulletCountUI;

    void Start()
    {
        currentBulletCount = MagazineSize;
        mStats = this.gameObject.GetComponent<Stats>();
    }

    void Update()
    {
        if (canFire == true)
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                firegun();
            }
            bulletCountUI.text = "Bullet: " + currentBulletCount;
            if (currentBulletCount == 0)
            {
                canFire = false;
                bulletCountUI.text = "Empty";
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            canFire = false;
            bulletCountUI.text = "Reloading..";
            Invoke("reload", reloadtime);
        }

    }

    void firegun()
    {
        if (currentBulletCount > 0)
        {
            GameObject Bullet = Instantiate(BulletPrefab, Nozzle.transform.position, transform.rotation) as GameObject;
            Bullet.GetComponent<BulletMovement>().damage = mStats.getWeaponDmg();


            //audioSource.PlayOneShot(ShootSFX);

            Destroy(Bullet, timerDestroy);

            currentBulletCount--;
        }
    }

    void reload()
    {
        currentBulletCount = MagazineSize;
        canFire = true;
    }

}
