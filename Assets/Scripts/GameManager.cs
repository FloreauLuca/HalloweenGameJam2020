using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool crucifixDown;
    private bool pictureDown;

    public void GameOver()
    {

    }

    public void Win()
    {
        SceneManager.LoadScene("Victoire");
    }

    public void Validate(bool crucifix)
    {
        if (crucifix)
        {
            crucifixDown = true;
        } else {
            pictureDown = true;
        }
        if (pictureDown && crucifixDown)
        {
            Win();
        }
    }
}
