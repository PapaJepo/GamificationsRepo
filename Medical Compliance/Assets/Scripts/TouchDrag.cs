using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDrag : MonoBehaviour
{
    [Header("Touch Timer")]
    [SerializeField]
    private float elapsed = 0f;
    [SerializeField]
    private float WaitTime = 1.5f;

    [Header("Touch Controls")]
    private Collider2D TouchCol;
    private Rigidbody2D rb;
    private SpriteRenderer Sprite;
    public float speed = 10f;

    [Header("Pet")]
    public GameObject Pet;
    public Animator PetAnim;
    public GameObject PetTrigger;

    [Header("Item Animator")]
    public Animator TreatController;
    

    [Header("Interactable Items")]
    public GameObject Item;
    public GameObject Item1;
    public GameObject Item2;

    private bool itemcheck;
    private bool itemcheck1;
    private bool itemcheck2;


    public Transform ItemPos;
    public Transform ItemPos1;
    public Transform ItemPos2;


    [Header("Item Menus")]
    public GameObject ItemHolder;
    public GameObject ItemMenu;
    public GameObject ItemButton;
    public GameObject Item1Button;

    [SerializeField] GameObject Meditation;

    [SerializeField] GameObject ItemMenuText;
    // Start is called before the first frame update

    private float introelapsed = 0f;

    void Start()
    {
        Time.timeScale = 1f;
        Sprite = GetComponent<SpriteRenderer>();
        PetAnim = Pet.GetComponent<Animator>();
        //ItemAnim = ItemController.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        TouchCol = GetComponent<BoxCollider2D>();
        TouchCol.enabled = false;
        var PetColour = Pet.GetComponent<SpriteRenderer>();
        // PetColour.material.SetColor("_Color", Color.red);
        Sprite.enabled = false;

        PetAnim.SetTrigger("Start");
        //PetAnim.SetBool("Intro",true);
      
    }

    // Update is called once per frame
    void Update()
    {
        
       /* introelapsed += Time.deltaTime;
        if (introelapsed > 2.35)
        {
            PetAnim.SetBool("Intro", false);
        }*/

        if (Input.touchCount > 0)
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
            if (itemcheck2 == true)
            {
                Item2.transform.position = touch1position;
            }
        }
        else
        {
            Sprite.enabled = false;
            TouchCol.enabled = false;
        }


        ////////////////////////////////////////////////////
        ///
        if (PetTrigger.GetComponent<Dog>().Treat == true)
        {

            elapsed += Time.fixedDeltaTime;
            if(elapsed>.8)
            {
                TreatController.SetTrigger("Treat");
                PetAnim.SetBool("Eating", true);
            }
          

        }



        //elapsed = 0;
        else if (PetTrigger.GetComponent<Dog>().Treat == false)
        {
            PetAnim.SetBool("Eating", false);
            elapsed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            Debug.Log("itemtouch");
            itemcheck = true;
            Pet.SetActive(true);
            ItemHolder.SetActive(false);
            Item1.SetActive(false);
            Item2.SetActive(false);

            ItemMenuText.SetActive(false);

            Meditation.SetActive(true);
        }
        if (collision.CompareTag("Item1"))
        {
            Debug.Log("itemtouch");
            itemcheck1 = true;
            Pet.SetActive(true);
            ItemHolder.SetActive(false);
           Item.SetActive(false);
            Item2.SetActive(false);

            ItemMenuText.SetActive(false);


            Meditation.SetActive(true);
        }
        if (collision.CompareTag("Item2"))
        {
            Debug.Log("itemtouch");
            itemcheck2 = true;
            Pet.SetActive(true);
            ItemHolder.SetActive(false);
            Item1.SetActive(false);
            Item.SetActive(false);

            ItemMenuText.SetActive(false);


            Meditation.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            //Pet.SetActive(false);
            itemcheck = false;
            Item1.SetActive(true);
            if(PlayerPrefs.GetInt("ItemKey1") > 0)
            {
                Item2.SetActive(true);
            }
            //
            ItemHolder.SetActive(true);
            ItemMenu.SetActive(false);
            //
            Item.transform.position = ItemPos.transform.position;
            //  Item1.transform.position = ItemPos1.transform.position;


            ItemButton.SetActive(true);
            Item1Button.SetActive(false);


            ItemMenuText.SetActive(true);

        }
        if (collision.CompareTag("Item1"))
        {
            //Pet.SetActive(false);
            itemcheck1 = false;
            Item.SetActive(true);
            if (PlayerPrefs.GetInt("ItemKey1") > 0)
            {
                Item2.SetActive(true);
            }
            //
            ItemHolder.SetActive(true);
            ItemMenu.SetActive(false);
            //
            //Item.transform.position = ItemPos.transform.position;
            Item1.transform.position = ItemPos1.transform.position;

            ItemButton.SetActive(true);
            Item1Button.SetActive(false);

            ItemMenuText.SetActive(true);

        }
        if (collision.CompareTag("Item2"))
        {
           // Pet.SetActive(false);
            itemcheck2 = false;
            Item.SetActive(true);
           Item1.SetActive(true);
            //
            ItemHolder.SetActive(true);
            ItemMenu.SetActive(false);
            //
            //Item.transform.position = ItemPos.transform.position;
            //Item1.transform.position = ItemPos1.transform.position;
            Item2.transform.position = ItemPos2.transform.position;

            ItemButton.SetActive(true);
            Item1Button.SetActive(false);

            ItemMenuText.SetActive(true);

        }


        ////////////////////


    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        
      
          
        
    }

    public void StopEating()
    {

    }

    public void MenuOpen()
    {
        PetAnim.SetTrigger("Idle");
    }
    /*
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
