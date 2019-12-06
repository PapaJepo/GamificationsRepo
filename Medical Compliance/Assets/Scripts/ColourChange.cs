using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    [SerializeField] List<GameObject> DogParts;
    [SerializeField] Color c1, c2, c3, c4;

    public GameObject Pet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(PlayerPrefs.GetInt("ColourKey"))
        {
            case 1:
                foreach (GameObject petpart in DogParts)
                {
                    petpart.GetComponent<SpriteRenderer>().material.SetColor("_Color", c1);
                }
                break;
            case 2:
                foreach (GameObject petpart in DogParts)
                {
                    petpart.GetComponent<SpriteRenderer>().material.SetColor("_Color", c2);
                }
                break;
            case 3:
                foreach (GameObject petpart in DogParts)
                {
                    petpart.GetComponent<SpriteRenderer>().material.SetColor("_Color", c3);
                }
                break;
            case 4:
                foreach (GameObject petpart in DogParts)
                {
                    petpart.GetComponent<SpriteRenderer>().material.SetColor("_Color", c4);
                }
                break;


        }
      
    }

    public void ColourSet()
    {
        var PetColour = Pet.GetComponent<SpriteRenderer>();
        PetColour.material.SetColor("_Color", Color.blue);
    }
}
