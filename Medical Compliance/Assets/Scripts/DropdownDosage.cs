using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownDosage : MonoBehaviour
{
    public Text text;
    public Dropdown Dosage;

    void Start()
    {
        Dosage.value = PlayerPrefs.GetInt("DosageKey");
    }

    void Update()
    {
        PlayerPrefs.SetInt("DosageKey", Dosage.value);
        switch (PlayerPrefs.GetInt("DosageKey"))
        {
            case 1:
                {
                    text.text = "prescription is " + Dosage.value;
                    break;
                }
            case 2:
                {
                    text.text = "prescription is " + Dosage.value;
                    break;
                }
            case 3:
                {
                    text.text = "prescription is " + Dosage.value;
                    break;
                }
        }
    }


    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("DosageKey", Dosage.value);
        //PlayerPrefs.Save("DosageKey");
    }
}
