using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeleteIndex()
    {

        // PlayerPrefs.SetInt("JournalKey", 0);

        PlayerPrefs.SetInt("JournalKey", 0);
        PlayerPrefs.SetInt("CoinKey", 0);

    }

    public void DeleteGameStart()
    {
        PlayerPrefs.SetInt("GameStartKey", 0);

    }
}
