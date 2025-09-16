using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemyCounter;
    [SerializeField] private TextMeshProUGUI dateText;

    [SerializeField] private GameObject defeatPanel;
    [SerializeField] private GameObject victoryPanel;

    // Update is called once per frame
    void Update()
    {
        enemyCounter.text = "Enemies Left: " + GlobalStats.EnemiesLeft;

        GlobalStats.ElapsedTime += Time.deltaTime;
        dateText.text = "Time Elapsed: " + GlobalStats.ElapsedTime.ToString("F1") + "s";

        bool winCodition = GlobalStats.EnemiesLeft <= 0;

        if (winCodition || GlobalStats.gameOver)
        {
            if (winCodition)
            {
                Victory(); 
            }
            else
            {
                Defeat();
            }
        }

    }


    public void Defeat()
    {
        defeatPanel.SetActive(true);
        Time.timeScale = 0;

    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0;

    }

}
