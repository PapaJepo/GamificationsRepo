using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditationAnim : MonoBehaviour
{
    public GameObject Pet;
    public Animator PetAnim;
    // Start is called before the first frame update
    void Start()
    {
        PetAnim.SetBool("Meditate", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
