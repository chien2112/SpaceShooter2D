using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderVFX;
    const string mixerMusic = "MusicBackground";
    const string mixerVFX = "Effect";

    private void Start()
    {
        sliderMusic.onValueChanged.AddListener(SetMusicVolume);
        sliderVFX.onValueChanged.AddListener(SetVFXVolume);

        sliderMusic.value = PlayerPrefs.GetFloat("MusicVolume", 10);
        sliderVFX.value = PlayerPrefs.GetFloat("VFXVolume", 10);   
    }
    void SetMusicVolume(float value)
    {
        audioMixer.SetFloat(mixerMusic, value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    void SetVFXVolume(float value)
    {
        audioMixer.SetFloat(mixerVFX, value);
        PlayerPrefs.SetFloat("VFXVolume", value);
    }
    
}
