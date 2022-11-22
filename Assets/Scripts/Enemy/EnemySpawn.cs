using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    Vector2 placeSpawn;
    public float spawnRate = 4f;
    float nextSpawn = 2.0f;


    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            float randX = Random.Range(-13.74f, 13.3f); 
            float randY = Random.Range(-11.84f, 12.2f);
            placeSpawn = new Vector2(randX, randY);
            Instantiate(enemy, placeSpawn,Quaternion.identity);
        }
    }
}