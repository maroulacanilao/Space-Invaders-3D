using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawnRandomPU : MonoBehaviour
{
    public GameObject Heal;
    public GameObject SpeedUp;
    public GameObject DoubleDmg;

    public int NextActionTime = 1;
    public int WaitingPeriod = 1;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > NextActionTime)
        {
            NextActionTime += WaitingPeriod;
            Spawn();
        }
    }

    GameObject RandomPowerUps()
    {
        float rng  = Random.Range(0.0f,1.0f );

        if (rng < 0.50f) return Heal;
        if ((rng >= 0.50f) && (rng < 0.75f)) return SpeedUp;
        return DoubleDmg;


        
    }
    void Spawn()
    {
        float X = Random.Range(-40.0f, 40.0f);

        GameObject PowerUp = Instantiate(RandomPowerUps(), new Vector3(X, 1, 0), transform.rotation);
        Destroy(PowerUp, 10.0f);
    }

}
