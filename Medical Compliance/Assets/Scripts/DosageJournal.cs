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

    void Start()
    {
        DosageArray = new string[31];
        DosageIndex = PlayerPrefs.GetInt("JournalKey");
        DosageAmount = PlayerPrefs.GetString("DosageAmountKey");


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
        PlayerPrefs.SetString("TimeList" + DosageIndex, DosageArray[DosageIndex]);
        PlayerPrefs.SetString("DosageList" + DosageIndex, DosageAmount);
        ScrollText.text = ScrollText.text + "\nDosage: " + (DosageIndex) + "\n" + PlayerPrefs.GetString("TimeList" + DosageIndex) + "\n" + "Dosage Taken: "  + PlayerPrefs.GetString("DosageList" + DosageIndex) + "\n" +" ";
        //DosageTime.Add(System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"));
        //PlayerPrefs.SetString("TimeList" + DosageIndex, DosageTime[DosageIndex]);
        //JournalText.text = PlayerPrefs.GetString("TimeList" + DosageIndex);
        int CoinTemp = PlayerPrefs.GetInt("CoinKey");
        CoinTemp++;
        PlayerPrefs.SetInt("CoinKey", CoinTemp);
        DosageIndex++;
        PlayerPrefs.SetInt("JournalKey", DosageIndex);

        Debug.Log("DosageTaken");

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
        // PlayerPrefs.SetInt("JournalKey", DosageIndex);
    }

    public void DeleteIndex()
    {
        
       // PlayerPrefs.SetInt("JournalKey", 0);
        
        PlayerPrefs.SetInt("JournalKey", 0);
        PlayerPrefs.SetInt("CoinKey", 0);

    }
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
