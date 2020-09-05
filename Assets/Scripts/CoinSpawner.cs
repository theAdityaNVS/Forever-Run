using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public Transform[] coinSpawnPosition;
    float timeBtwSpawn = 30f;

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(coin, coinSpawnPosition[Random.Range(0, coinSpawnPosition.Length)].position, Quaternion.identity);
            timeBtwSpawn = 30f;
        }
        else
        {
            timeBtwSpawn--;
        }
    }
}
