using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool GameStarted;
    public GameObject GameOverPanel;
    public GameObject StartingText; 
    public static int Coins=0;
    public static int Levels=1;
    public Text coinText;

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
        coinText.text="Coins: "+Coins;
        if(TouchControl.tap)
        {
            GameStarted=true;
            StartingText.SetActive(false);
        }
    }
}
