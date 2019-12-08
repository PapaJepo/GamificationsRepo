using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnim : MonoBehaviour
{
   // public Animator TreatController;
    public GameObject Treat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopEating()
    {
        Treat.SetActive(false);
        Treat.SetActive(true);
        //MeditationButton.SetActive(true);
    }
}
