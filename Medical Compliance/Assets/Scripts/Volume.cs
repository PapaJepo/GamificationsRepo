using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
   public AudioMixer audiomixer;
    public AudioMixer audiomixer1;

    [SerializeField] Slider Slider1;
    [SerializeField] Slider Slider2;

    private float volumesave, volume1save;

    private void Start()
    {
        audiomixer.SetFloat("volume", PlayerPrefs.GetFloat("Volume1Key"));
        audiomixer1.SetFloat("volume", PlayerPrefs.GetFloat("Volume2Key"));
        Slider1.value = PlayerPrefs.GetFloat("Volume1Key");
        Slider2.value = PlayerPrefs.GetFloat("Volume2Key");
    }

    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("Volume1Key", volume);
        volumesave = volume;
    }

    public void SetVolumeSFX(float volume)
    {
        audiomixer1.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("Volume2Key", volume);
        volume1save = volume;
        
    }

    private void OnApplicationQuit()
    {
        volumesave = Slider1.value;
        volume1save = Slider2.value;
        PlayerPrefs.SetFloat("Volume1Key", volumesave);
        PlayerPrefs.SetFloat("Volume2Key", volume1save);
    }
}
