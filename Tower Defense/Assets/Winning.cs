using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winning : MonoBehaviour
{
    public Text roundsText;
    public Text winningText;
    public ScreenFader screenFader;
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    private void OnEnable()
    {
        winningText.text = "YOU WON!\n";
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void NextLevel()
    {
        screenFader.FadeTo(nextLevel);
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
