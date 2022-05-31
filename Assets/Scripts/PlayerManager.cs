using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool GameStarted;
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        GameStarted = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver==true)
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
