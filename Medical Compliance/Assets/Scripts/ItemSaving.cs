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

    [SerializeField] GameObject Object2;
    [SerializeField] Transform Object2Pos;

    [SerializeField] GameObject Object3;
    [SerializeField] Transform Object3Pos;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("ItemKey1")>0)
        {
            //Item.transform.position = ItemPos.transform.position;
            Object1.SetActive(true);
           // Object1.transform.position = Object1Pos.transform.position;
        }

        if (PlayerPrefs.GetInt("ItemKey2") > 0)
        {
            //Item.transform.position = ItemPos.transform.position;
            Object2.SetActive(true);
            Object2.transform.position = Object2Pos.transform.position;
        }
        if (PlayerPrefs.GetInt("ItemKey3") > 0)
        {
            //Item.transform.position = ItemPos.transform.position;
            Object3.SetActive(true);
            Object3.transform.position = Object3Pos.transform.position;
        }


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("ItemKey1"));
        if (PlayerPrefs.GetInt("ItemKey1") > 0)
        {
            //Item.transform.position = ItemPos.transform.position;
            Object1.SetActive(true);
            // Object1.transform.position = Object1Pos.transform.position;
        }
    }

    public void DeletePurchaseHistory()
    {
        PlayerPrefs.SetInt("ItemKey1", 0);
        PlayerPrefs.SetInt("ItemKey2", 0);
        PlayerPrefs.SetInt("ItemKey3", 0);

    }

    public void PurchaseSave()
    {
        if (PlayerPrefs.GetInt("ItemKey1") > 0)
        {
            //Item.transform.position = ItemPos.transform.position;
            Object1.SetActive(true);
            //Object1.transform.position = Object1Pos.transform.position;
        }
        if (PlayerPrefs.GetInt("ItemKey2") > 0)
        {
            //Item.transform.position = ItemPos.transform.position;
            Object2.SetActive(true);
            Object2.transform.position = Object2Pos.transform.position;
        }
        if (PlayerPrefs.GetInt("ItemKey3") > 0)
        {
            //Item.transform.position = ItemPos.transform.position;
            Object3.SetActive(true);
            Object3.transform.position = Object3Pos.transform.position;
        }

    }
}
