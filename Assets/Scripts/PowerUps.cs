using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    Stats mStats;
    int OriginalWeaponDmg;
    float OriginalSpeed;
    AudioSource mAudioSource;

    public GameObject Heal_VFX;
    public AudioClip Heal_SFX;
    public Text HealText;

    public GameObject Speed_VFX;
    public AudioClip Speed_SFX;
    public GameObject SpeedIco;
    public Slider SpeedProgression;

    public GameObject DMG2_VFX;
    public AudioClip DMG2_SFX;
    public GameObject DMG2Ico;
    public Slider DMG2Progression;

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

            StartCoroutine(Heal());
        }
        if (collider.gameObject.CompareTag("PwrUp.SpeedUp"))
        {
            Destroy(collider.gameObject);

            StartCoroutine(SpeedUp());
        }
        if (collider.gameObject.CompareTag("PwrUp.2xDamage"))
        {
            Destroy(collider.gameObject);
            StartCoroutine(DoubleDmg());
        }
    }


    void PlayEffects(GameObject VFX, AudioClip SFX, float time)
    {
        var TempVFX = Instantiate(VFX, gameObject.transform);
        mAudioSource.PlayOneShot(SFX);
        Destroy(TempVFX, time);
    }

    IEnumerator SpeedUp()
    {
        SpeedIco.SetActive(true);
        SpeedProgression.enabled = true;

        mStats.setSpeed(OriginalSpeed * 2);

        PlayEffects(Speed_VFX, Speed_SFX, 20);

        for(int i = 20; i>0; i--)
        {
            float x = (float)i / 20.0f;
            SpeedProgression.value = x;
            yield return new WaitForSeconds(1);
        }
        mStats.setSpeed(OriginalSpeed);
        SpeedIco.SetActive(false);
        SpeedProgression.enabled = true;
    }

    IEnumerator DoubleDmg()
    {
        DMG2Ico.SetActive(true);
        DMG2Progression.enabled = true;

        mStats.setWeaponDmg(OriginalWeaponDmg * 2);

        PlayEffects(DMG2_VFX, DMG2_SFX, 20);

        for (int i = 20; i > 0; i--)
        {
            float x = (float)i / 20.0f;
            DMG2Progression.value = x;
            yield return new WaitForSeconds(1);
        }
        mStats.setWeaponDmg(OriginalWeaponDmg);
        DMG2Ico.SetActive(false);
        DMG2Progression.enabled = false;
    }

    IEnumerator Heal()
    {
        HealText.gameObject.SetActive(true);
        int HealValue = Random.Range(1, 3);
        mStats.SetCurrentHp(mStats.getCurrentHp() + HealValue);
        HealText.text = "+" + HealValue;
        PlayEffects(Heal_VFX, Heal_SFX, 2);

        yield return new WaitForSeconds(3);
        HealText.text = "";
        HealText.gameObject.SetActive(false);
    }
}
