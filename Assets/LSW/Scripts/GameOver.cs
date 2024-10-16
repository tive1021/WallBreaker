using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    public void IsGameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }
}
