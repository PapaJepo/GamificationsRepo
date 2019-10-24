using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownDosage : MonoBehaviour
{
    public Text text;
  //  public Dropdown Dosage;
    public TMPro.TMP_Dropdown TMPdrop;
    private string textpref;

    void Start()
    {
       
        TMPdrop.value = PlayerPrefs.GetInt("DosageKey");
        textpref = PlayerPrefs.GetString("DosageAmountKey");

    }

    void Update()
    {
        PlayerPrefs.SetInt("DosageKey", TMPdrop.value);
        switch (PlayerPrefs.GetInt("DosageKey"))
        {
            case 0:
                {
                   // text.text = "";
                    break;
                }
            case 1:
                {
                    PlayerPrefs.SetString("DosageAmountKey", "5mg");
                    text.text = "prescription is " + PlayerPrefs.GetString("DosageAmountKey"); ;

                    break;
                }
            case 2:
                {
                    PlayerPrefs.SetString("DosageAmountKey", "10mg");
                    text.text = "prescription is " + PlayerPrefs.GetString("DosageAmountKey"); ;

                    break;
                }
            case 3:
                {
                    PlayerPrefs.SetString("DosageAmountKey", "20mg");

                    text.text = "prescription is " + PlayerPrefs.GetString("DosageAmountKey"); ;

                    break;
                }
        }
    }


    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("DosageKey", TMPdrop.value);
        
        PlayerPrefs.Save();
    }
}
