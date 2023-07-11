using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public ScreenFader screen;
    public Button[] levelButtons;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1); // to save Player's data

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1  > levelReached)
            {
                levelButtons[i].interactable = false;
            }

        }
    }

    public void Select(string levelName)
    {
        screen.FadeTo(levelName);
    }
}
