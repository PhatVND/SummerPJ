using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerLinking : MonoBehaviour
{
    public static  GameObject enemyLinking1;
    public static GameObject enemyLinking2;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveNumber = 0;


    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

    }
    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber * waveNumber + 2; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {

      GameObject enemyL1 = (GameObject)Instantiate(enemyLinking1, spawnPoint.position, spawnPoint.rotation);
      GameObject enemyL2 = (GameObject)Instantiate(enemyLinking2, spawnPoint.position, spawnPoint.rotation);
    }
}
