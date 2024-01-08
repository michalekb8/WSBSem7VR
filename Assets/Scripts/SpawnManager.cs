using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int waveNumber = 1;

    float minRadius = 0.1f;
    float maxradius = 8f;

    int enemiesToSpawn = 1;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            enemiesToSpawn = Random.Range(1, waveNumber);
            SpawnEnemyWave(enemiesToSpawn);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, generateSpawnPoint(), Quaternion.identity);
        }
    }

    Vector3 generateSpawnPoint()
    {
        float randomAngle = Random.Range(0f, 360f);
        float radians = Mathf.Deg2Rad * randomAngle;

        float x = Random.Range(minRadius, maxradius) * Mathf.Cos(radians);
        float z = Random.Range(minRadius, maxradius) * Mathf.Sin(radians);

        Vector3 spawnPoint = new Vector3(x, 1.6f, z);

        return spawnPoint;
    }
}
