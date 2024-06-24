using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{


    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider soundFXSlider;
    public Slider ambienceSlider;

    const string mixer_Master = "Master";
    const string mixer_Music = "Music";
    const string mixer_SoundFX = "SoundFX";
    const string mixer_Ambience = "Ambience";


    // Sound Sliders

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        soundFXSlider.onValueChanged.AddListener(SetSoundFXVolume);
        ambienceSlider.onValueChanged.AddListener(SetAmbienceVolume);

    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("mixer_Master", Mathf.Log10(value) * 20);
    }
    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("mixer_Music", Mathf.Log10(value) * 20);
    }
    public void SetSoundFXVolume(float value)
    {
        audioMixer.SetFloat("mixer_SoundFX", Mathf.Log10(value) * 20);
    }
    public void SetAmbienceVolume(float value)
    {
        audioMixer.SetFloat("mixer_Ambience", Mathf.Log10(value) * 20);
    }


}
