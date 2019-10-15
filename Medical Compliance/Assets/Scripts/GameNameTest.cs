using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameNameTest : MonoBehaviour
{
    public Text NameText;
    // Start is called before the first frame update
    void Start()
    {
        NameText.text = PlayerPrefs.GetString("NameKey");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
