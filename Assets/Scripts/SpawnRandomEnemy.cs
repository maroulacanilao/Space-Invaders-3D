using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SpawnRandomEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab_1;
    public GameObject EnemyPrefab_2;
    public GameObject EnemyPrefab_3;
    public GameObject EnemyPrefab_4;
    public GameObject EnemyPrefab_5;

    public GameObject WaveUI;
    public Text WaveText;

    int NumOfSpwnEnemy = 0;
    int WaveCount;
    float mult;
    GameObject[] Fleet;
    struct coordinateXZ
    {
        public float x;
        public float z;


    }
    coordinateXZ[] location = new coordinateXZ[36];
    void Start()
    {
        int index = 0;
        float XC = -75.0f;

        for (int a = 0; a < 6; a++)
        {
            float ZC = 40.0f;
            for (int s = 0; s < 6; s++)
            {
                location[index].z = ZC;
                location[index].x = XC;
                ZC += 18.0f;
                index++;
            }
            XC += 30.0f;
        }

        WaveCount = 0;
        mult =1.10f;
    }

    void Update()
    {
        Fleet = GameObject.FindGameObjectsWithTag("Enemy");
        NumOfSpwnEnemy = Fleet.Length;


        if (NumOfSpwnEnemy == 0)
        {
            WaveCount++;
            WaveEnemies();
            mult += 0.05f;
        }

    }

    int RandomLocation()
    {
        int randindex = Random.Range(0, location.Length);

        for(int i =0; i< NumOfSpwnEnemy;i++)
        {
            int n = Fleet[i].GetComponent<EnemyBehaviour>().locationNum;

            if (randindex != n)
            {
                Debug.Log("SAME!!!!");
                RandomLocation();
            }
        }
        return randindex;
    }

    void SpawnEnemy()
    {
        int loc = RandomLocation();
        GameObject SpawnedEnemy = Instantiate(RandomEnemy(), new Vector3(location[loc].x, 1, location[loc].z), transform.rotation);
        SpawnedEnemy.GetComponent<EnemyBehaviour>().locationNum = loc;
    }

    GameObject RandomEnemy()
    {
        float x = Random.Range(0, 1.0f) * mult;

        if ((x >= 0.40f) && (x < 0.70f)) return EnemyPrefab_1; //2nd weakest
        if ((x >= 0.70f) && (x < 0.85f)) return EnemyPrefab_2; //3rd Weakest
        if ((x >= 0.85f) && (x < 0.95f)) return EnemyPrefab_4;
        if ((x >= 0.95f)) return EnemyPrefab_5; //Strongest
        else return EnemyPrefab_3; //Weakest
    }

    void WaveEnemies()
    {
        int x = (int)mult * 3;
        for(int i = 0; i<x;i++)
        {
            SpawnEnemy();
        }
    }
}
