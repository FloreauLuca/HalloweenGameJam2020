using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject center;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject zero;
    [SerializeField] private GameObject one;
    [SerializeField] private GameObject two;
    [SerializeField] private GameObject three;
    [SerializeField] private GameObject four;
    [SerializeField] private GameObject five;
    [SerializeField] private GameObject six;
    [SerializeField] private GameObject seven;
    [SerializeField] private GameObject eight;
    [SerializeField] private GameObject nine;
    [SerializeField] private GameObject ten;
    [SerializeField] private GameObject eleven;
    [SerializeField] private GameObject twelve;
    [SerializeField] private GameObject thirtheen;
    private TimeManager timeManager;
    void Start()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (timeManager.GameTime)
        {
            case 0:
                thirtheen.SetActive(false);
                zero.SetActive(true);
                break;
            case 1:
                zero.SetActive(false);
                one.SetActive(true);
                break;
            case 2:
                one.SetActive(false);
                two.SetActive(true);
                break;
            case 3:
                two.SetActive(false);
                three.SetActive(true);
                break;
            case 4:
                three.SetActive(false);
                four.SetActive(true);
                break;
            case 5:
                four.SetActive(false);
                five.SetActive(true);
                break;
            case 6:
                five.SetActive(false);
                six.SetActive(true);
                break;
            case 7:
                six.SetActive(false);
                seven.SetActive(true);
                break;
            case 8:
                seven.SetActive(false);
                eight.SetActive(true);
                break;
            case 9:
                eight.SetActive(false);
                nine.SetActive(true);
                break;
            case 10:
                nine.SetActive(false);
                ten.SetActive(true);
                break;
            case 11:
                ten.SetActive(false);
                eleven.SetActive(true);
                break;
            case 12:
                eleven.SetActive(false);
                twelve.SetActive(true);
                break;
            case 13:
                twelve.SetActive(false);
                thirtheen.SetActive(true);
                break;
        }
    }
}
