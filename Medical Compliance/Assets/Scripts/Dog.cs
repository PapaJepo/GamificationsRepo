using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField]
    private float elapsed = 0f;

    public bool Treat;

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
