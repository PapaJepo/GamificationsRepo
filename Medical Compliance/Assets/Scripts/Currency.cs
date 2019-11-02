using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    public TMPro.TMP_Text CoinTest;
    [SerializeField]
    private int CoinAmount;
    // Start is called before the first frame update
    void Start()
    {
        CoinAmount = PlayerPrefs.GetInt("CoinKey");
    }

    // Update is called once per frame
    void Update()
    {
        CoinTest.text = "" + CoinAmount;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CoinKey", CoinAmount);
    }

    public void Purchase()
    {
        if (CoinAmount > 0)
        {
            CoinAmount = CoinAmount - 1;
        }
        
    }
}

