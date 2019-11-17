using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DosageJournal : MonoBehaviour
{
    private int DosageIndex;
    private string DosageAmount;
    // public Text ScrollText;
    public TMPro.TMP_Text ScrollText;
    public string[] DosageArray;

    [SerializeField]
    private List<string> DosageTime = new List<string>();



    int Day;
    int Month;
    int CurrentDay;

    void Start()
    {
        DosageArray = new string[31];
        DosageIndex = PlayerPrefs.GetInt("JournalKey");
        DosageAmount = PlayerPrefs.GetString("DosageAmountKey");
        Day = PlayerPrefs.GetInt("CurrentDayKey");
        Debug.Log(Day);
        Debug.Log("DosageIndex: " + DosageIndex);
        Month = PlayerPrefs.GetInt("CurrentMonthKey");
        CurrentDay = PlayerPrefs.GetInt("DosageDay");

        for (int i = 0; i < DosageIndex; i++)
        {
            DosageTime.Add(PlayerPrefs.GetString("TimeString" + i));
            DosageTime[i] = PlayerPrefs.GetString("TimeString" + i);
         
        }
        for (int i = 0; i < DosageIndex; i++)
        {
            
            DosageArray[i] = PlayerPrefs.GetString("TimeList" + i);
            DosageTime[i] = DosageArray[i];
            ScrollText.text = ScrollText.text + "\nDosage: " + (i) + "\n" + PlayerPrefs.GetString("TimeList" + i) + "\n" + "Dosage Taken: " + PlayerPrefs.GetString("DosageList" + i) + "\n" + " ";
        }


        // JournalText.text = PlayerPrefs.GetString("TimeList" + DosageIndex);
    }

    void Update()
    {
        DosageAmount = PlayerPrefs.GetString("DosageAmountKey");
        for (int i = 0; i < DosageIndex; i++)
        {

            DosageArray[i] = PlayerPrefs.GetString("TimeList" + i);
            //DosageTime[i] = DosageArray[i];
        }
    }

    public void DosageTaken()
    {
        Debug.Log("------------------------------------------------");
        
        DosageArray[DosageIndex] = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
        
       // Day = (int)System.DateTime.Now.Day;
       // Month = (int)System.DateTime.Now.Month;

       

        if(DosageIndex == 0)
        {
            Day = (int)System.DateTime.Now.Day;
            Month = (int)System.DateTime.Now.Month;
            PlayerPrefs.SetInt("CurrentDayKey", Day);
            PlayerPrefs.SetInt("CurrentMonthKey", Month);

            //if(PlayerPrefs.GetInt("CurrentDayKey") > )
        }

        if((int)System.DateTime.Now.Month > PlayerPrefs.GetInt("CurrentMonthKey"))
        {
            PlayerPrefs.SetInt("CurrentDayKey", Day);
            PlayerPrefs.SetInt("CurrentMonthKey", Month);
        }

        if ((int)System.DateTime.Now.Day > PlayerPrefs.GetInt("CurrentDayKey"))


        if (Day == PlayerPrefs.GetInt("CurrentDayKey") && Month == PlayerPrefs.GetInt("CurrentMonthKey"))
        {
            CurrentDay = 1;
        }


        // Debug.Log(test);
        if ((int)System.DateTime.Now.Day > PlayerPrefs.GetInt("CurrentDayKey") || DosageIndex == 0)
        {
            PlayerPrefs.SetString("TimeList" + DosageIndex, DosageArray[DosageIndex]);
            PlayerPrefs.SetString("DosageList" + DosageIndex, DosageAmount);
            ScrollText.text = ScrollText.text + "\nDosage: " + (DosageIndex) + "\n" + PlayerPrefs.GetString("TimeList" + DosageIndex) + "\n" + "Dosage Taken: " + PlayerPrefs.GetString("DosageList" + DosageIndex) + "\n" + " ";
            //DosageTime.Add(System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"));
            //PlayerPrefs.SetString("TimeList" + DosageIndex, DosageTime[DosageIndex]);
            //JournalText.text = PlayerPrefs.GetString("TimeList" + DosageIndex);
            int CoinTemp = PlayerPrefs.GetInt("CoinKey");
            CoinTemp += 10;
            PlayerPrefs.SetInt("CoinKey", CoinTemp);
            DosageIndex++;
            PlayerPrefs.SetInt("JournalKey", DosageIndex);

            Debug.Log("DosageTaken");
            /////////////////////////////////
            ///
           // Day++; 
            PlayerPrefs.SetInt("CurrentDayKey", (int)System.DateTime.Now.Day);
            //PlayerPrefs.SetInt("CurrentMonthKey", Month+1);
            CurrentDay = 0;
        }
        else 
        {
            Debug.Log("Dosage taken take another day");
           //Debug.Log(PlayerPrefs.GetInt("DosageDay"));
        }
    }

    void OnApplicationQuit()
    {
        /*for (int i = 0; i < DosageIndex; i++)
        {
           
            PlayerPrefs.SetString("TimeList" + i, DosageTime[i]);
        }*/
        for (int i = 0; i < DosageIndex; i++)
        {

            DosageArray[i] = PlayerPrefs.GetString("TimeList" + i);
            PlayerPrefs.SetString("TimeList" + i, DosageArray[i]);
        }

        PlayerPrefs.SetString("DosageAmountKey", DosageAmount);
        PlayerPrefs.SetInt("CurrentDayKey", Day);
        PlayerPrefs.SetInt("CurrentMonthKey", Month);
        PlayerPrefs.SetInt("DosageDay",CurrentDay);

        // PlayerPrefs.SetInt("JournalKey", DosageIndex);
    }
    /*
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
    */
    public void CheckSave()
    {
        Debug.Log("------------------------------------------------");
        for (int i = 0; i < DosageIndex; i++)
        {
            Debug.Log(PlayerPrefs.GetString("TimeList" + i));
           // PlayerPrefs.SetString("TimeList" + i, DosageTime[i]);
        }
        Debug.Log("Save Checked");
       
    }
}
