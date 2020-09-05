using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPosition : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] enemySpawnPosition;
    float timeBtwSpawn = 30f;

    void Update()
    {
        if(timeBtwSpawn<=0)
        {
            Instantiate(enemy, enemySpawnPosition[Random.Range(0, enemySpawnPosition.Length)].position, Quaternion.identity);
            timeBtwSpawn = 30f;
        }
        else
        {
            timeBtwSpawn--;
        }
    }
}
