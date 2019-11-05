using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int GameStart;
    public GameObject StartMenu;
    // Start is called before the first frame update
    void Start()
    {
        GameStart = PlayerPrefs.GetInt("GameStartKey");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameStart);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameEdit()
    {
        GameStart = GameStart + 1;
        PlayerPrefs.SetInt("GameStartKey", GameStart);
        if (PlayerPrefs.GetInt("GameStartKey") < 2)
        {
            StartMenu.SetActive(true);
        }
        else
        {
            LoadGame();
        }
    }

    public void LoadGame()
    {
      
        SceneManager.LoadScene(1);

    }

    public void LoadRun()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitApp()
    {
        PlayerPrefs.SetInt("GameStartKey", GameStart);
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
