using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 15f;
    private float countdown = 2f;

    private int waveNumber = 0;
    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        if(waveNumber < 3)
        {
            waveNumber++;
        }
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.8f);
        }
    }
    void SpawnEnemy()
    {
        GameObject enemy = ObjectPool.SharedInstance.GetPooledObject(3);
        if(enemy != null)
        {
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation;
            enemy.SetActive(true);
        }
    }
}
