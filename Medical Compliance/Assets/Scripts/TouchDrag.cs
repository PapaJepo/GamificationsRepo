using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDrag : MonoBehaviour
{
    [SerializeField]
    private float elapsed = 0f;
    [SerializeField]
    private float WaitTime = 1.5f;

    private Rigidbody2D rb;
    public float speed = 10f;
    public GameObject Pet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var PetColour = Pet.GetComponent<SpriteRenderer>();
        PetColour.material.SetColor("_Color", Color.red);
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

            if (touch1.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Pet"))
        {
         
            elapsed += Time.fixedDeltaTime;
            if (elapsed > WaitTime)
            {
                var PetColour = Pet.GetComponent<SpriteRenderer>();
                PetColour.material.SetColor("_Color", Color.blue);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pet"))
        {
            elapsed = 0;
            var PetColour = Pet.GetComponent<SpriteRenderer>();
            PetColour.material.SetColor("_Color", Color.red);
        }
    }
}
