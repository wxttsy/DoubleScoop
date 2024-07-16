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
    public float musicVolume;
    public float soundFXVolume;
    public float ambienceVolume;


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
        musicVolume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSoundFXVolume()
    {
        soundFXVolume = soundFXSlider.value;
        audioMixer.SetFloat("SoundFX", Mathf.Log10(soundFXVolume) * 20);
        PlayerPrefs.SetFloat("SoundFXVolume", soundFXVolume);
    }

    public void SetAmbienceVolume()
    {
        ambienceVolume = ambienceSlider.value;
        audioMixer.SetFloat("Ambience", Mathf.Log10(ambienceVolume) * 20);
        PlayerPrefs.SetFloat("AmbienceVolume", ambienceVolume);
    }
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundFXSlider.value = PlayerPrefs.GetFloat("soundFXVolume");
    }





}
