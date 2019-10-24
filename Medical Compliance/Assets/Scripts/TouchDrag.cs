﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDrag : MonoBehaviour
{
    [SerializeField]
    private float elapsed = 0f;
    [SerializeField]
    private float WaitTime = 1.5f;

    public Animator PetAnim;
    private Collider2D TouchCol;
    private Rigidbody2D rb;
    private SpriteRenderer Sprite;
    public float speed = 10f;
    public GameObject Pet;
    public GameObject Item;
    public GameObject Item1;
    private bool itemcheck;
    private bool itemcheck1;
    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        PetAnim = Pet.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        TouchCol = GetComponent<BoxCollider2D>();
        TouchCol.enabled = false;
        var PetColour = Pet.GetComponent<SpriteRenderer>();
        // PetColour.material.SetColor("_Color", Color.red);
        Sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Sprite.enabled = true;
            Touch touch1 = Input.GetTouch(0);
            Vector3 touch1position = Camera.main.ScreenToWorldPoint(touch1.position);
            touch1position.z = 0;
            Vector3 direction = (touch1position - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * speed;
            TouchCol.enabled = true;
            if (touch1.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
            
            if(itemcheck == true)
            {
                Item.transform.position = touch1position;
            }
            if (itemcheck1 == true)
            {
                Item1.transform.position = touch1position;
            }
        }
        else
        {
            Sprite.enabled = false;
            TouchCol.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            Debug.Log("itemtouch");
            itemcheck = true;
        }
        if (collision.CompareTag("Item1"))
        {
            Debug.Log("itemtouch");
            itemcheck1 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Debug.Log("itemtouch");
            itemcheck = false;
        }
        if (collision.CompareTag("Item1"))
        {
            Debug.Log("itemtouch");
            itemcheck1 = false;
        }
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Pet"))
        {
         
            elapsed += Time.fixedDeltaTime;
            if (elapsed > WaitTime)
            {
                var PetColour = Pet.GetComponent<SpriteRenderer>();
                //PetColour.material.SetColor("_Color", Color.blue);
                PetAnim.SetTrigger("Brush");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pet"))
        {
            elapsed = 0;
            var PetColour = Pet.GetComponent<SpriteRenderer>();
            //PetColour.material.SetColor("_Color", Color.red);
        }
    }
    */
}
