using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    Stats mStats;
    int OriginalWeaponDmg;
    float OriginalSpeed;
    AudioSource mAudioSource;

    public GameObject Heal_VFX;
    public AudioClip Heal_SFX;

    public GameObject Speed_VFX;
    public AudioClip Speed_SFX;

    public GameObject DMG2_VFX;
    public AudioClip DMG2_SFX;

    private void Start()
    {
        mStats = gameObject.GetComponent<Stats>();
        OriginalWeaponDmg = mStats.getWeaponDmg();
        OriginalSpeed = mStats.getMovementSpeed();
        mAudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PwrUp.Heal"))
        {
            Destroy(collider.gameObject);
            mStats.SetCurrentHp(mStats.getCurrentHp() + Random.Range(1, 3));

            PlayEffects(Heal_VFX, Heal_SFX, 2);
        }
        if (collider.gameObject.CompareTag("PwrUp.SpeedUp"))
        {
            Destroy(collider.gameObject);
            mStats.setSpeed(OriginalSpeed * 2);

            PlayEffects(Speed_VFX, Speed_SFX, 10);

            StartCoroutine(RemoveSpeedUpEffect(10));
        }
        if (collider.gameObject.CompareTag("PwrUp.2xDamage"))
        {
            Destroy(collider.gameObject);
            mStats.setWeaponDmg(OriginalWeaponDmg * 2);

            PlayEffects(DMG2_VFX, DMG2_SFX, 10);

            StartCoroutine(RemoveDoubleDmgEffect(10));
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

    void PlayEffects(GameObject VFX, AudioClip SFX, float time)
    {
        var TempVFX = Instantiate(VFX, gameObject.transform);
        mAudioSource.PlayOneShot(SFX);
        Destroy(TempVFX, time);
    }
}
