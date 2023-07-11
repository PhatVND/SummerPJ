using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public Text money;
    public Text playerLives;
    public Text playerDFS;
    public Text waveText;
    void Update()
    {
        money.text = "$" + PlayerStats.money.ToString();
        playerLives.text = "Lives: " + PlayerStats.Lives.ToString();
        playerDFS.text = "Dragon Fragments: " + PlayerStats.dragonFragments.ToString();
    }
}
