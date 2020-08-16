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
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    GameObject RandomPowerUps()
    {
        float rng  = Random.Range(0.0f,1.0f );

        if (rng < 0.50f) return Heal;
        if ((rng >= 0.50f) && (rng < 0.75f)) return SpeedUp;
        return DoubleDmg;
    }
    public void Spawn()
    {
        float rng = Random.Range(0.0f, 1.0f);

        if (rng < 0.5f)
        {
            float X = Random.Range(-90.0f, 90.0f);
            GameObject PowerUp = Instantiate(RandomPowerUps(), new Vector3(X, 1, -40), transform.rotation);
            Destroy(PowerUp, 10.0f);
        }
    }

}
