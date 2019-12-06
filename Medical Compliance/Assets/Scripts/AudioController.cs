using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    AudioSource ButtonPress;
    AudioSource Transition;
    AudioSource BGM;
    AudioSource Meditation;
    AudioSource Purchase;
    AudioSource Click;
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
