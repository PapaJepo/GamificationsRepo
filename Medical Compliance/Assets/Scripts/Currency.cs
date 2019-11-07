using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    [Header("Currency")]
    public TMPro.TMP_Text CoinTest;
    [SerializeField] private int CoinAmount;

    [Header("Item1")]
    [SerializeField] TMPro.TMP_Text Item1Text;
    [SerializeField] GameObject Item1Button;
    private int Item1Save;
    
    // Start is called before the first frame update
    void Start()
    {
        CoinAmount = PlayerPrefs.GetInt("CoinKey");
    }

    // Update is called once per frame
    void Update()
    {
        CoinTest.text = "" + CoinAmount;

        if(PlayerPrefs.GetInt("ItemKey1")>0)
        {
            Item1Button.GetComponent<Button>().enabled = !true;
            Item1Text.text = "Purchased";
        }
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
            Item1Save++;
            PlayerPrefs.SetInt("ItemKey1", Item1Save);

        }
        
    }
}

