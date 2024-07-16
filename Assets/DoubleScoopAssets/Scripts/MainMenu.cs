using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject MenuScreen;
    [SerializeField] GameObject SettingsScreen;
    [SerializeField] GameObject ControlsScreen;

    public void Awake()
    {
        MenuScreen.SetActive(true);
    }

    public void OpenSettingsScreen()
    {
        SettingsScreen.SetActive(true);
        MenuScreen.SetActive(false);
    }
    public void CloseSettingsScreen()
    {
        SettingsScreen.SetActive(false);
        MenuScreen.SetActive(true);
    }

    public void OpenControlsScreen()
    {
        ControlsScreen.SetActive(true);
        MenuScreen.SetActive(false);
    }
    public void CloseControlsScreen()
    {
        ControlsScreen.SetActive(false);
        MenuScreen.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("GameHasQuit");
    }
}
