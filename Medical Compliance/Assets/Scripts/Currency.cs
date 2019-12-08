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
    [SerializeField] TMPro.TMP_Text Item2Text;
    [SerializeField] TMPro.TMP_Text Item3Text;
    [SerializeField] GameObject Item1Button;
    [SerializeField] GameObject Item2Button;
    [SerializeField] GameObject Item3Button;

    [SerializeField] GameObject SoldOut;
    private int Item1Save,Item2Save,Item3Save;
    
    // Start is called before the first frame update
    void Start()
    {
        CoinAmount = PlayerPrefs.GetInt("CoinKey");
        if (PlayerPrefs.GetInt("ItemKey1") > 0 && PlayerPrefs.GetInt("ItemKey2") > 0 && PlayerPrefs.GetInt("ItemKey3") > 0)
        {
            SoldOut.SetActive(true);
        }
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
        if (PlayerPrefs.GetInt("ItemKey2") > 0)
        {
            Item2Button.GetComponent<Button>().enabled = !true;
            Item2Text.text = "Purchased";
        }
        if (PlayerPrefs.GetInt("ItemKey3") > 0)
        {
            Item3Button.GetComponent<Button>().enabled = !true;
            Item3Text.text = "Purchased";
        }

        if(PlayerPrefs.GetInt("ItemKey1") > 0 && PlayerPrefs.GetInt("ItemKey2") > 0 && PlayerPrefs.GetInt("ItemKey3") > 0)
        {
            SoldOut.SetActive(true);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CoinKey", CoinAmount);
    }

    public void Purchase1()
    {
        if (CoinAmount > 0)
        {
            CoinAmount = CoinAmount - 1;
            Item1Save++;
            PlayerPrefs.SetInt("ItemKey1", Item1Save);

        }
        
    }

    public void Purchase2()
    {
        if (CoinAmount > 0)
        {
            CoinAmount = CoinAmount - 1;
            Item2Save++;
            PlayerPrefs.SetInt("ItemKey2", Item2Save);

        }

    }
    public void Purchase3()
    {
        if (CoinAmount > 0)
        {
            CoinAmount = CoinAmount - 1;
            Item3Save++;
            PlayerPrefs.SetInt("ItemKey3", Item3Save);

        }

    }
}

