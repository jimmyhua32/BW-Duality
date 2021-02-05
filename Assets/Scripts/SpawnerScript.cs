using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public GameObject flipCirclePrefab;
    public float maxSpawnTime;

    private float lastSpawnTime = 0;


    // Update is called once per fixed interval
    void FixedUpdate()
    {
        if (Time.time - lastSpawnTime > maxSpawnTime)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            float y = Random.Range(-5, 5);
            Instantiate(enemyPrefab, new Vector3(10, y, 0), Quaternion.identity);
            lastSpawnTime = Time.time;

            if (Random.Range(0, 6) == 0)
            {
                Instantiate(flipCirclePrefab, new Vector3(10, Random.Range(-5, 5)), Quaternion.identity);
            }
        }
    }
}
