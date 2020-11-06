using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int gameTime = 0;
    private float currentTime;

    [SerializeField] private float Time1Hour = 5;
    [SerializeField] private float Time13thHour = 30;

    public int GameTime
    {
        get { return gameTime; }
    }

    void Start()
    {
        gameTime = 0;
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (gameTime >= 13)
        {
            if (currentTime > Time13thHour)
            {
                gameTime = 0;
                currentTime -= Time13thHour;
            }
        }
        else
        {
            
            if (currentTime > Time1Hour)
            {
                gameTime += 1;
                currentTime -= Time1Hour;
            }
        }
    }
}
