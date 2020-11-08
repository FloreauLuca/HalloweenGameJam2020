using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private int gameTime = 0;
    private float currentTime;

    [SerializeField] private float time1Hour = 5;
    [SerializeField] private float time13thHour = 30;

    [SerializeField] private GameObject filter13;

    public int GameTime
    {
        get { return gameTime; }
    }

    public float CurrentTime
    {
        get { return currentTime; }
    }

    public float Time1Hour
    {
        get { return time1Hour; }
    }

    public float Time13thHour
    {
        get { return time13thHour; }
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
            filter13.SetActive(true);
            if (currentTime > Time13thHour)
            {
                gameTime = 0;
                currentTime -= Time13thHour;
            }
        }
        else
        {
            filter13.SetActive(false);
            if (currentTime > Time1Hour)
            {
                gameTime += 1;
                currentTime -= Time1Hour;
            }
        }
    }
}
