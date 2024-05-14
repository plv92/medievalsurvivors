using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject settingsWindow;
    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
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
    }
}
