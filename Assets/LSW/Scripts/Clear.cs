using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    private int totalBricks;
    public static Clear Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        totalBricks = FindObjectsOfType<Brick>().Length;
    }

    public void OnBrickDestroyed()
    {
        totalBricks--;
        if (totalBricks <= 0)
        {
            GameClear();
        }
    }

    private void GameClear()
    {
     
    }
}
