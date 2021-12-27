using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Map1");
    }

    public void Settýngs()
    {
        SceneManager.LoadSceneAsync("SettingsScene");// Settýngs = 1
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    public void Back()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
