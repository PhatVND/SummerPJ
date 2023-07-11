using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver = false;
    public static bool winGame = false;

    public GameObject gameOverUI;
    public GameObject winGameUI;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public ScreenFader fader;


    // Start is called before the first frame update
    void Start()
    {
        gameIsOver = false;
        winGame = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver || winGame)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            EndGame();
        }
        if (PlayerStats.Lives <= 0 )
        {
            EndGame();
        }

        if (Enemy.bossKilled)
        {
            if (WaveSpawner.EnemiesAlive <= 0)
            {
                WinGame();
                PlayerPrefs.SetInt("levelReached", levelToUnlock);
            } 
        }
        
    }
    private void EndGame()
    {
        gameOverUI.SetActive(true);
        gameIsOver = true;
    }
    private void WinGame()
    {
        winGameUI.SetActive(true);
        winGame = true;
        return;
        
    }

}
