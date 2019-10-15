using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    public InputField Name_Input;
    // Start is called before the first frame update
    void Start()
    {
        Name_Input.text = PlayerPrefs.GetString("NameKey");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void UserInput(string Name)
    {
        Debug.Log(Name);
        PlayerPrefs.SetString("NameKey", Name);

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("NameKey", Name_Input.text);
    }
}
