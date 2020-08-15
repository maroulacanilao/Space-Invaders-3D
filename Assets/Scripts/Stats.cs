using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Stats : MonoBehaviour
{
    [SerializeField] public int mMaxHealth = 1;
    [SerializeField] private int mCurrentHealth;
    [SerializeField] private float mMovementSpeed = 0;
    [SerializeField] private int mWeaponDamage = 1;
    

    private void Start()
    {
        mCurrentHealth = mMaxHealth;
    }
    private void Update()
    {
        if (mCurrentHealth <= 0) mCurrentHealth = 0;
        if (mCurrentHealth > mMaxHealth) mCurrentHealth = mMaxHealth;
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

    public void setSpeed(float speed)
    {
        mMovementSpeed = speed;
    }

    public void setWeaponDmg(int Damage)
    {
        mWeaponDamage = Damage;
    }

    public float calculateHealth()
    {
        return (float)mCurrentHealth / (float)mMaxHealth;

    }
}
