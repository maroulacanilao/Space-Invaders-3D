using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] public int mMaxHealth = 1;
    [SerializeField] private int mCurrentHealth;
    [SerializeField] private float mMovementSpeed = 0;
    [SerializeField] private int mWeaponDamage = 1;
    [SerializeField] private int scoreOnKill = 1;

    private void Start()
    {
        mCurrentHealth = mMaxHealth;
    }
    private void Update()
    {
        if (mCurrentHealth <= 0)
        {
            mCurrentHealth = 0;
            if(!this.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
                Score.totalScore += scoreOnKill;

            }
            if (this.gameObject.CompareTag("Player"))
            {
                Debug.Log("u lose");
            }
        }
    }

    public int getCurrentHp()
    {
        return mCurrentHealth;
    }

    public int getMaxHP()
    {
        return mMaxHealth;
    }

    public float getMovementSpeed()
    {
        return mMovementSpeed;
    }

    public int getWeaponDmg()
    {
        return mWeaponDamage;
    }

    public void SetCurrentHp(int Hp)
    {
        mCurrentHealth = Hp;
    }

    public void setSpeed(int speed)
    {
        mMovementSpeed = speed;
    }

    public void setWeaponDmg(int Damage)
    {
        mWeaponDamage = Damage;
    }
}
