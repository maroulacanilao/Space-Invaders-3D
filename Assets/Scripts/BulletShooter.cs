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
    public AudioClip ShootSFX;
    public AudioClip ReloadSFX;
    public AudioClip DryFire;
    AudioSource mAudioSource;

    int currentBulletCount;
    bool canFire = true;
    float reloadtime = 1;
    Stats mStats;

    public Text bulletCountUI;

    void Start()
    {
        currentBulletCount = MagazineSize;
        mStats = this.gameObject.GetComponent<Stats>();
        mAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canFire == true)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                firegun();
            }
            bulletCountUI.text = "Bullet: " + currentBulletCount;
            if (currentBulletCount <= 0)
            {
                canFire = false;
                bulletCountUI.text = "Empty";
            }
        }
        if ((!canFire) && (Input.GetKeyDown(KeyCode.Space))) mAudioSource.PlayOneShot(DryFire);

        if (Input.GetKeyDown(KeyCode.R))
        {
            canFire = false;
            mAudioSource.PlayOneShot(ReloadSFX);
            bulletCountUI.text = "Reloading..";
            Invoke("reload", reloadtime);
        }
       
    }

    void firegun()
    {
        if (currentBulletCount > 0)
        {
            GameObject Bullet = Instantiate(BulletPrefab, Nozzle.transform.position, transform.rotation);
            Bullet.GetComponent<BulletMovement>().damage = mStats.getWeaponDmg();
            Bullet.GetComponent<Renderer>().material.SetColor("_Color", Color.green);


            mAudioSource.PlayOneShot(ShootSFX);

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
