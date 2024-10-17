using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class IgnoreBall : MonoBehaviour
{

    private void Start()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject Ball in balls)

        {
            if (Ball != this.gameObject)
            {
                Physics2D.IgnoreCollision(Ball.GetComponent<Collider2D>() , GetComponent<Collider2D>());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D addBall)
    {
        if (addBall.CompareTag("Ball"))
        {
            Physics2D.IgnoreCollision(addBall, GetComponent<Collider2D>());
        }
    }
}


