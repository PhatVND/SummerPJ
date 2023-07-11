using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 250;
    public static int Lives;
    public int startLives = 10;
    public static int dragonFragments;
    private int startDragonFragments = 0;

    public  static int Rounds;

    private void Start()
    {
        money = startMoney;
        Lives = startLives;
        dragonFragments = startDragonFragments;

        Rounds = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            money = 999999;
            dragonFragments = 999999;
        } 
    }

}
