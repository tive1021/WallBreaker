using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnInfinityButtonClick()
    {
        SceneManager.LoadScene("InfinityModeScene");
    }
}
