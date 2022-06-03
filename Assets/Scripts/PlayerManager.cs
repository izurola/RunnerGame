using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool GameStarted;
    public static bool winRound;
    public GameObject GameOverPanel;
    public GameObject StartingText; 
    public GameObject WinRoundPanel;
    public static int Coins=0;
    public static int Levels=100;
    public static int TotalCoin=0;
    public Text coinText;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        GameStarted = false;
        winRound = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver==true)
        {
            Coins=TotalCoin;
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
        coinText.text="Coins: "+Coins;
        levelText.text="Level: "+Levels;
        if(TouchControl.tap)
        {
            GameStarted=true;
            StartingText.SetActive(false);
        }
        if(winRound)
        {
            TotalCoin=Coins;
            Time.timeScale = 0;
            WinRoundPanel.SetActive(true);
        }
    }
}
