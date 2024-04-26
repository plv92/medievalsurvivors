using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LeveltoLoad;
    public GameObject settingsWindow;
    public void StartGame()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }

    public void closeSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    public void Settings()
    {
        settingsWindow.SetActive(true);
    }
    public void Quitgame()
    {
        Application.Quit();
    }}
