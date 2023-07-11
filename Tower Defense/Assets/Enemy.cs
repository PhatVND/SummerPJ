using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int moneyReward = 50;
    public bool isBoss = false;
    public float startSpeed = 5f;
    private float health;
    public static bool bossKilled = false;

    [HideInInspector]
    public float speed = 5f;

    public float startHealth = 100;
    [Header("Unity Stuff")]
    public Image healthBar;



    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {

        health -= amount;
        healthBar.fillAmount = health / startHealth;
        Die();
    }

    public void Die()
    {
        if (health <= 0)
        {
            int randnum = Random.Range(1, 10);
            if (isBoss) bossKilled = true;
            if (randnum % 2 == 0)
            {
                PlayerStats.money += moneyReward;
                PlayerStats.dragonFragments++;
            }
            Destroy(gameObject);
            WaveSpawner.EnemiesAlive--;
        }

    }

    public void Slow(float pct)
    {
        speed = speed * (1f - pct);
    }




}
