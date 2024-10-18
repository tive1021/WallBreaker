using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void OnExitButtonClicked()
    { 
        SceneManager.LoadScene("IntroScene");
        Time.timeScale = 1f;
    }
}


