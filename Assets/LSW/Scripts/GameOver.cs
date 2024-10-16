using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject ball;
    public GameObject gameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BottomWall"))
        {
            IsGameOver();
        }
    }

    private void IsGameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }
}
