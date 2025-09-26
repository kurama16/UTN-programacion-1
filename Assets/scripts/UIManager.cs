using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dateText;

    [SerializeField] private GameObject defeatPanel;
    [SerializeField] private GameObject victoryPanel;

    void Update()
    {
        if (GlobalStats.gameOver)
        {
            if (GlobalStats.wavesCleared)
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
