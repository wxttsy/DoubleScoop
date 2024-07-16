using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject PauseScreen;
    [SerializeField] GameObject SettingsScreen;
    [SerializeField] GameObject ControlsScreen;
    bool isPaused = false;
    private void Awake()
    {
        PauseScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        ControlsScreen.SetActive(false);
    }

    public void TogglePauseScreen()
    {
        PauseScreen.SetActive(!PauseScreen.activeSelf);
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void OpenSettingsScreen()
    {
        SettingsScreen.SetActive(true);
        PauseScreen.SetActive(false);
    }
    public void CloseSettingsScreen()
    {
        SettingsScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }

    public void OpenControlsScreen()
    {
        ControlsScreen.SetActive(true);
        PauseScreen.SetActive(false);
    }
    public void CloseControlsScreen()
    {
        ControlsScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("GameHasQuit");
    }


}

