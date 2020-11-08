using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    void Update()
    {
        if (Time.timeSinceLevelLoad > 7)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
