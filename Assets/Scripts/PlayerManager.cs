using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver = false;
    public GameObject gameoverpanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver==true)
        {
            gameoverpanel.SetActive(true);
        }
    }

    internal static void isPlaying(bool v)
    {
        throw new NotImplementedException();
    }
}
