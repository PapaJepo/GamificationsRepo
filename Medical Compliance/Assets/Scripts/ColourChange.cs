using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{

    public GameObject Pet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColourSet()
    {
        var PetColour = Pet.GetComponent<SpriteRenderer>();
        PetColour.material.SetColor("_Color", Color.blue);
    }
}
