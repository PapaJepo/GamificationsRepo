using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownTime : MonoBehaviour
{
   // public Text text;
    public Dropdown Time;
    public TMPro.TMP_Dropdown TMPdrop;
    // Start is called before the first frame update
    void Start()
    {
        Time.value = PlayerPrefs.GetInt("TimeKey");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("TimeKey", TMPdrop.value);
        switch (PlayerPrefs.GetInt("TimeKey"))
        {
            case 0:
                {
                   // text.text = "";
                    break;
                }
            case 1:
                {
                    //text.text = "notification time is 08:00";
                    break;
                }
            case 2:
                {
                    //text.text = "notification time is 10:00";
                    break;
                }
            case 3:
                {
                   // text.text = "notification time is 12:00";
                    break;
                }
            case 4:
                {
                    //text.text = "notification time is 14:00";
                    break;
                }
            case 5:
                {
                    //text.text = "notification time is 16:00";
                    break;
                }
            case 6:
                {
                    //text.text = "notification time is 18:00";
                    break;
                }
            case 7:
                {
                   // text.text = "notification time is 20:00";
                    break;
                }
        }

    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("TimeKey", Time.value);
    }
}
