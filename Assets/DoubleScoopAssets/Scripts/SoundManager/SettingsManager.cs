using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{


    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider soundFXSlider;
    public Slider ambienceSlider;
    public float masterVolume;

    private void Start()
    {
        SetMasterVolume();
        SetMusicVolume();
        SetSoundFXVolume();
        SetAmbienceVolume();
    }


    public void SetMasterVolume()
    {
        masterVolume = masterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(masterVolume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSoundFXVolume()
    {
        float volume = soundFXSlider.value;
        audioMixer.SetFloat("SoundFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SoundFXVolume", volume);
    }

    public void SetAmbienceVolume()
    {
        float volume = ambienceSlider.value;
        audioMixer.SetFloat("Ambience", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("AmbienceVolume", volume);
    }
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundFXSlider.value = PlayerPrefs.GetFloat("soundFXVolume");
    }





}
