using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaving : MonoBehaviour
{
   // [SerializeField] List<GameObject> Items;
   // [SerializeField] List<Transform> ItemPos;
    [Header("Object")]
    [SerializeField] GameObject Object1;
    [SerializeField] Transform Object1Pos;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("ItemKey1")>0)
        {
            //Item.transform.position = ItemPos.transform.position;
            Object1.SetActive(true);
            Object1.transform.position = Object1Pos.transform.position;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("ItemKey1"));
    }

    public void DeletePurchaseHistory()
    {
        PlayerPrefs.SetInt("ItemKey1", 0);
    }

    public void PurchaseSave()
    {
        if (PlayerPrefs.GetInt("ItemKey1") > 0)
        {
            //Item.transform.position = ItemPos.transform.position;
            Object1.SetActive(true);
            Object1.transform.position = Object1Pos.transform.position;
        }
       
    }
}
