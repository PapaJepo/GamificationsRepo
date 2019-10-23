using System.Collections;
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
    public float speed = 10f;
    public GameObject Pet;
    public GameObject Item;
    private bool itemcheck;
    // Start is called before the first frame update
    void Start()
    {
        PetAnim = Pet.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        TouchCol = GetComponent<BoxCollider2D>();
        TouchCol.enabled = false;
        var PetColour = Pet.GetComponent<SpriteRenderer>();
       // PetColour.material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
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
        }
        else
        {
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Debug.Log("itemtouch");
            itemcheck = false;
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
