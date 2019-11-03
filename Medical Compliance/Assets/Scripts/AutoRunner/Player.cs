using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpvelocity = 100f;
    public float speed = 5f;
    private float jumpcount = 0f;
    public int coinamount;

    [SerializeField] GameObject Button;
    [SerializeField] TMPro.TMP_Text CoinText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        Debug.Log(jumpcount);
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && jumpcount > 0)
        {
            rb.AddForce(new Vector2(0f, jumpvelocity), ForceMode2D.Force);
            jumpcount--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            if (jumpcount < 1)
            {
                jumpcount++;
            }
        }

        if (collision.CompareTag("Coin"))
        {
            var coin = collision.gameObject;
            coinamount = coinamount + 1;
            CoinText.text = "" + coinamount/2;
            Destroy(coin);
            
        }

        if (collision.CompareTag("FallDetector"))
        {
            Time.timeScale = 0f;
            Button.SetActive(true);
        }

    }
 
    
}
