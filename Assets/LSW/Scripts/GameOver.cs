using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject ball;

    void Update()
    {
        if (ball.transform.position.y <= -5f)
        {
            IsGameOver();
        }
    }

    private void IsGameOver()
    {
        
    }
}
