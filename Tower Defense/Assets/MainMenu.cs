using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject helpUI;
    public string levelToLoad = "Level01";

    public ScreenFader screenFader;
    public void Play()
    {
        screenFader.FadeTo(levelToLoad);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            helpUI.SetActive(false);
        }
        if (Input.GetKey(KeyCode.T))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void Quit()
    {
        Debug.Log("Exciting..");
        Application.Quit();
    }
    public void Help()
    {
        helpUI.SetActive(true);
    }
}
