using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void StartGame()
    {
        Time.timeScale = 1;
        GlobalStats.ElapsedTime = 0;
        GlobalStats.EnemiesLeft = GlobalStats.TotalEnemies;
        GlobalStats.gameOver = false;
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
