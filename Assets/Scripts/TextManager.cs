using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private GameObject panel;
    [SerializeField] private float duration;
    private float timer;

    void Update() {
        if (timer > duration)
        {
            panel.SetActive(false);
        } else {
            timer += Time.deltaTime;
        }
    }

    public void DisplayText(string text)
    {
        textMesh.text = text;
        timer = 0.0f;
        panel.SetActive(true);
    }

}
