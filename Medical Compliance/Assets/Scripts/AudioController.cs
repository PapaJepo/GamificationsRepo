using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    AudioSource ButtonPress;
    [SerializeField] AudioSource Transition;
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource Meditation;
    [SerializeField] AudioSource Purchase;
    [SerializeField] AudioSource Click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressFunction()
    {
        ButtonPress.Play();
    }

    public void TransitionFunction()
    {
        Transition.Play();
    }

    public void BGMFunction()
    {
        BGM.Play();
    }

    public void MeditationFunction()
    {
        Meditation.Play();
    }

    public void PurchaseFunction()
    {
        Purchase.Play();
    }

    public void ClickFunction()
    {
        Click.Play();
    }
}
