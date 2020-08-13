using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    Stats mStats;
    int OriginalWeaponDmg;
    float OriginalSpeed;

    public GameObject Heal_VFX;
    private void Start()
    {
        mStats = gameObject.GetComponent<Stats>();
        OriginalWeaponDmg = mStats.getWeaponDmg();
        OriginalSpeed = mStats.getMovementSpeed();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PwrUp.Heal"))
        {
            Destroy(collider.gameObject);
            mStats.SetCurrentHp(mStats.getCurrentHp() + Random.Range(1,3));

            var HVFX = Instantiate(Heal_VFX, gameObject.transform);
            Destroy(HVFX, 1);
        }
        if (collider.gameObject.CompareTag("PwrUp.SpeedUp"))
        {
            Destroy(collider.gameObject);
            mStats.setSpeed(OriginalSpeed * 2);
            StartCoroutine(RemoveSpeedUpEffect(2));
        }
        if (collider.gameObject.CompareTag("PwrUp.2xDamage"))
        {
            Destroy(collider.gameObject);
            mStats.setWeaponDmg(OriginalWeaponDmg * 2);
            StartCoroutine(RemoveDoubleDmgEffect(2));

        }
    }

    IEnumerator RemoveSpeedUpEffect(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        mStats.setSpeed(OriginalSpeed);
    }

    IEnumerator RemoveDoubleDmgEffect(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        mStats.setWeaponDmg(OriginalWeaponDmg);
    }
}
