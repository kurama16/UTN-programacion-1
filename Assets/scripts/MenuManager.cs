using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void StartGame()
    {
        Time.timeScale = 1;
        GlobalStats.gameOver = false;
        GlobalStats.wavesCleared = false;
        SceneManager.LoadScene("Arena");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");

    }
}
