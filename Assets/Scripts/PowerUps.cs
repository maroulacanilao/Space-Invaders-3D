using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    Stats mStats;
    private void Start()
    {
        mStats = gameObject.GetComponent<Stats>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PwrUp.Heal"))
        {
            Destroy(collider.gameObject);
            //mStats.Heal(Random.Range(1, 3));
        }
        if (collider.gameObject.CompareTag("PwrUp.SpeedUp"))
        {
            Destroy(collider.gameObject);
            //mStats.changeSpeed(100);
            //Invoke
        }
        if (collider.gameObject.CompareTag("PwrUp.2xDamage"))
        {
            Destroy(collider.gameObject);
            //mStats.WeaponDamageMultiplier(mStats.WeaponDamage * 2);
            //Invoke
        }
    }
}
