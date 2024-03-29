﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dog : MonoBehaviour
{
    //[SerializeField]
    //private float elapsed1 = 0f;
    //[SerializeField]
   // private float elapsed2 = 0f;

    [SerializeField] AudioSource BarkSFX;
    [SerializeField] AudioClip BarkClip;

    public bool Treat;
    public bool Brush;
    public bool Pet;
    [SerializeField] GameObject ButtonScript;

    [SerializeField] GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnUI()
    {
        UI.SetActive(true);
    }
    public void HideUI()
    {
        UI.SetActive(false);

    }
    public void ActiveButton()
    {
        ButtonScript.GetComponent<Button>().enabled = true;
    }
    public void INActiveButton()
    {
        ButtonScript.GetComponent<Button>().enabled = false;
    }

  

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Item1"))
        {
            //elapsed = 0;
           // elapsed += Time.fixedDeltaTime;
            //if(elapsed>1)
            //{
                Treat = true;
                //Debug.Log("Treat over Pet");
            //}
           
        }

        else if (collision.CompareTag("Item"))
        {
            //elapsed = 0;
            // elapsed += Time.fixedDeltaTime;
            //if(elapsed>1)
            //{
            Brush = true;
           Debug.Log("Brush over Pet");
            //}

        }

        else if(collision.CompareTag("Finger") )
        {
            Debug.Log("Petting");
            Pet = true;
        }
     

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item1"))
        {
            //elapsed1 = 0;
            Treat = false;
            Debug.Log("Treat gone");
        }

        if (collision.CompareTag("Item"))
        {
            //elapsed2 = 0;
            Brush = false;
            Debug.Log("Brush gone");
        }
        if (collision.CompareTag("Finger"))
        {
            Debug.Log("Petting");
            Pet = false;
        }

    }

    void Bark()
    {
        BarkSFX.PlayOneShot(BarkClip);
    }
}
