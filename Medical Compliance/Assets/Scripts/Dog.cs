﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField]
    private float elapsed = 0f;

    public bool Treat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
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
                Debug.Log("Brush over Pet");
            //}
           
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item1"))
        {
            elapsed = 0;
            Treat =false;
            Debug.Log("Brush gone");
        }
    }
}