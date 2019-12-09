using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int GameStart;
    public GameObject StartMenu;
    [SerializeField] GameObject Dog;
    // Start is called before the first frame update
    void Start()
    {
        GameStart = PlayerPrefs.GetInt("GameStartKey");
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(GameStart);
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
            Dog.SetActive(true);
        }
        else
        {
            Dog.SetActive(false);
            LoadGame();
        }
    }

    public void LoadGame()
    {
      
        SceneManager.LoadScene(1);

    }

    public void LoadMed()
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
