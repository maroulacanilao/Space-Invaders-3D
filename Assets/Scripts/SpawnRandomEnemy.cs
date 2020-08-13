using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawnRandomEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab_1;
    public GameObject EnemyPrefab_2;
    public GameObject EnemyPrefab_3;
    public GameObject EnemyPrefab_4;
    public GameObject EnemyPrefab_5;

    int NumOfSpwnEnemy;
    //int[] xCoordinate;
    float[] yCoordinate = new float[7];
    void Start()
    {
        yCoordinate[0] = 45.0f;
        yCoordinate[1] = 55.0f;
        yCoordinate[2] = 65.0f;
        yCoordinate[3] = 75.0f;
        yCoordinate[4] = 85.0f;
        yCoordinate[5] = 95.0f;
        yCoordinate[6] = 105.0f;

        InvokeRepeating("Spawn", 0, 1);
    }

    void Update()
    {
        //NumOfSpwnEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //if (NumOfSpwnEnemy <5) RandomLocation();
        
    }

    void RandomLocation()
    {
        float randX = Random.Range(-43.0f, 43.0f);
        int randindex = Random.Range(1,7);
        GameObject SpawnedEnemy = Instantiate(RandomEnemy(), new Vector3(randX, 1, yCoordinate[randindex]), transform.rotation);
    }

    GameObject RandomEnemy()
    {
        int x = Random.Range(1, 5);
        if (x == 2) return EnemyPrefab_2;
        if (x == 3) return EnemyPrefab_3;
        if (x == 4) return EnemyPrefab_4;
        if (x == 5) return EnemyPrefab_5;
        return EnemyPrefab_1;
    }

    void Spawn()
    {
        NumOfSpwnEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (NumOfSpwnEnemy < 5) RandomLocation();
    }
}
