using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackgroundAmbient : MonoBehaviour
{
    [SerializeField] private AudioClip ticTac;
    [SerializeField] private AudioClip darkAmbient;
    [SerializeField] private AudioClip piano;
    [SerializeField] private AudioClip boom;
    [SerializeField] private AudioSource backgroundAmbientSource;
    [SerializeField] private AudioSource pianoSource;
    [SerializeField] private AudioSource boomSource;
    [SerializeField] private TimeManager timeManager;

    [SerializeField] private float timeBeforeEndToLaunchPiano = 12f;

    private bool is13th;
    private bool isPianoSourcePlaying;

    private void Start()
    {
        is13th = true;
    }

    private void Update()
    {
        if (timeManager.GameTime < 13 && is13th)
        {
            pianoSource.Stop();
            backgroundAmbientSource.clip = ticTac;
            backgroundAmbientSource.loop = true;
            backgroundAmbientSource.Play();
            is13th = false;
            isPianoSourcePlaying = false;
        }
        else if (timeManager.GameTime >= 13 && is13th == false)
        {
            backgroundAmbientSource.clip = darkAmbient;
            backgroundAmbientSource.loop = true;
            backgroundAmbientSource.Play();
            boomSource.clip = boom;
            boomSource.Play();
            is13th = true;
        }

        if (is13th == true)
        {
            if (timeManager.CurrentTime + timeBeforeEndToLaunchPiano > timeManager.Time13thHour && !isPianoSourcePlaying)
            {
                pianoSource.clip = piano;
                pianoSource.Play();
                isPianoSourcePlaying = true;
            }
        }


    }


}
