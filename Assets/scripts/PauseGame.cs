using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseGame : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;
    // Update is called once per frame
    void Update()
    {

        //pause game
        if (!GlobalStats.gameOver && Input.GetKeyDown(KeyCode.P))
        {
            Boolean isPaused = Time.timeScale == 0;

            if (isPaused)
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1;

            }
            else
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }
}
