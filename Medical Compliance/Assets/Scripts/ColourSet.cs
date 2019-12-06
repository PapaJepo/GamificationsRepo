using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSet : MonoBehaviour
{
    [SerializeField] int Colour;
    // Start is called before the first frame update
    void Start()
    {
        Colour = PlayerPrefs.GetInt("ColourKey");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColour1()
    {
        Colour = 1;
        PlayerPrefs.SetInt("ColourKey", Colour);
    }
    public void SetColour2()
    {
        Colour = 2;
        PlayerPrefs.SetInt("ColourKey", Colour);
    }
    public void SetColour3()
    {
        Colour = 3;
        PlayerPrefs.SetInt("ColourKey", Colour);
    }
    public void SetColour4()
    {
        Colour = 4;
        PlayerPrefs.SetInt("ColourKey", Colour);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("ColourKey", Colour);

        PlayerPrefs.Save();
    }
}
