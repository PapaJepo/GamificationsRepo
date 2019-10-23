using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DosageJournal : MonoBehaviour
{
    private int DosageIndex;
    private string DosageAmount;
    public Text ScrollText;
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
            ScrollText.text = ScrollText.text + "\n Day: " + (i) + "\n" + PlayerPrefs.GetString("TimeList" + i) + "\n" + "Dosage Taken: " + DosageAmount + "\n" + "";
        }


        // JournalText.text = PlayerPrefs.GetString("TimeList" + DosageIndex);
    }

    void Update()
    {
 
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
        ScrollText.text = ScrollText.text + "Day: " + (DosageIndex) + "\n" + PlayerPrefs.GetString("TimeList" + DosageIndex) + "\n" + "Dosage Taken: "  + DosageAmount + "\n" +"";
        //DosageTime.Add(System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"));
        //PlayerPrefs.SetString("TimeList" + DosageIndex, DosageTime[DosageIndex]);
        //JournalText.text = PlayerPrefs.GetString("TimeList" + DosageIndex);
        
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
