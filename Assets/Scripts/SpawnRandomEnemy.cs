using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnRandomEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab_1;
    public GameObject EnemyPrefab_2;
    public GameObject EnemyPrefab_3;
    public GameObject EnemyPrefab_4;
    public GameObject EnemyPrefab_5;

    public int NumOfSpwnEnemy = 0;

    public int Wave;
    float mult;
    //float[] yCoordinate = new float[36];
    GameObject[] Fleet;
    struct coordinateXZ
    {
        public float x;
        public float z;


    }
    coordinateXZ[] location = new coordinateXZ[36];
    void Start()
    {
        //yCoordinate[0] = 45.0f;
        //yCoordinate[1] = 55.0f;
        //yCoordinate[2] = 65.0f;
        //yCoordinate[3] = 75.0f;
        //yCoordinate[4] = 85.0f;
        //yCoordinate[5] = 95.0f;
        //yCoordinate[6] = 105.0f;

        //InvokeRepeating("Spawn", 0, 1);
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

        //for (int i = 0; i < 36; i++)
        //{
        //    Debug.Log("LOC#" + i +
        //      " X: " + location[i].x + " " + "Y: " + location[i].z);
        //}

        Wave = 0;
        mult =1.10f;
        Debug.Log(float.MaxValue);
    }

    void Update()
    {
        //NumOfSpwnEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;

        Fleet = GameObject.FindGameObjectsWithTag("Enemy");
        NumOfSpwnEnemy = Fleet.Length;


        if(NumOfSpwnEnemy == 0)
        {
            Wave++;
            WaveEnemies();
            mult += 0.05f;
        }

    }

    int RandomLocation()
    {
        int randindex = UnityEngine.Random.Range(0, 36);
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
        float x = UnityEngine.Random.Range(0, 1.0f) * mult;

        if ((x >= 0.40f) && (x < 0.70f)) return EnemyPrefab_1; //2nd weakest
        if ((x >= 0.70f) && (x < 0.85f)) return EnemyPrefab_2; //3rd Weakest
        if ((x >= 0.85f) && (x < 0.95f)) return EnemyPrefab_4;
        if ((x >= 0.95f)) return EnemyPrefab_5; //Strongest
        else return EnemyPrefab_3; //Weakest
    }

    void WaveEnemies()
    {
        int x = Convert.ToInt32(mult) * 3;
        for(int i = 0; i<x;i++)
        {
            SpawnEnemy();
        }
    }
}
