using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int time = 0;
    private float currentTime;

    [SerializeField] private float Time1Hour = 5;
    [SerializeField] private float Time13thHour = 30;
    void Start()
    {
        time = 0;
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (time >= 13)
        {
            if (currentTime > Time13thHour)
            {
                time = 0;
                currentTime -= Time13thHour;
            }
        }
        else
        {
            
            if (currentTime > Time1Hour)
            {
                time += 1;
                currentTime -= Time1Hour;
            }
        }
    }
}
