using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] public AudioSource mainBGM;
    [SerializeField] public AudioSource bossSound;
    [SerializeField] public AudioSource bossBGM;
    public GameObject AssitantUI;
    public GameObject AssitantUI_wave2;
    public GameObject AssitantUI_wave3;
    public GameObject AssitantUI_boss;


    public GameObject bossUI;
    public static int EnemiesAlive = 0;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject boss_Child;
    public GameObject enemyBoss;
    public GameObject enemyPrefab2_2nd;
    public GameObject enemyPrefab3_2nd;

    public Transform spawnPoint;

    public GameObject Particle;
    public float timeBetweenWaves = 20f;
    private float countdown = 5f;
    private int startWave = 0;
    private int waveNumber;

    public Text waveCountdownText;
    public Text waveText;

    private void Start()
    {
        waveNumber = startWave;
        mainBGM.Play();
    }

    private void Update()
    {
        StartCoroutine(Announce());
        if (Input.GetKeyDown(KeyCode.P))
        {
            waveNumber = 14;
        }


        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            if (waveNumber == 15)
            {
                countdown = 9999;
            }
            else
            {
                countdown = timeBetweenWaves;
            }
                return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown).ToString();
        waveText.text = "Wave\n" + Mathf.Round(waveNumber).ToString() + "/15";


    }

    IEnumerator Announce()
    {
        yield return new WaitForSeconds(0.5f);
        if (waveNumber == 0)
        {
            AssitantUI.SetActive(true);
        }
        yield return new WaitForSeconds(15f);
        AssitantUI.SetActive(false);
        //wave 2
        yield return new WaitForSeconds(0.5f);
        if (waveNumber == 2)
        {
            AssitantUI_wave2.SetActive(true);
        }
        yield return new WaitForSeconds(15f);
        if (waveNumber != 2)
            AssitantUI_wave2.SetActive(false);
        //wave 5
        if (waveNumber == 5)
        {
           AssitantUI_wave3.SetActive(true);
        }
       yield return new WaitForSeconds(15f);
       if (waveNumber != 5)
           AssitantUI_wave3.SetActive(false);
        // wave 14
        if (waveNumber == 14)
        {
            AssitantUI_boss.SetActive(true);
        }
        yield return new WaitForSeconds(15f);
        if (waveNumber != 14)
            AssitantUI_boss.SetActive(false);

    }


    IEnumerator SpawnWave()
    { 
        Debug.Log(waveNumber);
        PlayerStats.Rounds++;
        waveNumber++;
        PlayerStats.money += (waveNumber * 25 + 150);

        if (waveNumber % 2 == 0)
        {
            for (int i = 0; i < waveNumber; i++)
            {
                SpawnEnemy(enemyPrefab3);
                yield return new WaitForSeconds(1f);
            }
        }


        if (waveNumber == 15)
        {
            yield return new WaitForSeconds(2f);
            GameObject effect = (GameObject)Instantiate(Particle, spawnPoint.position, spawnPoint.rotation);
            Destroy(effect, 2f);
            mainBGM.Stop();
            bossSound.Play();
            bossBGM.PlayDelayed(3f);
            for (int i = 1; i < 3; i++)
            {
                SpawnEnemy(boss_Child);
            }
            SpawnEnemy(enemyBoss);
            for (int i = 0; i < waveNumber; i++)
            {
                SpawnEnemy(enemyPrefab3_2nd);
                yield return new WaitForSeconds(1f);
            }
            for (int i = 0; i < waveNumber - 8; i++)
            {
                SpawnEnemy(enemyPrefab2_2nd);
                yield return new WaitForSeconds(1f);

            }
        }


        else
        {

            if (waveNumber % 5 == 0)
            {
                Debug.Log("Enemy Wave 5");
                for (int i = 0; i < waveNumber; i++)
                {
                    SpawnEnemy(enemyPrefab2);
                    yield return new WaitForSeconds(1f);
                }
            }

            for (int i = 0; i < waveNumber * 2 + 2; i++)
            {
                SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(1f);
            }
        }
    }
    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

}
