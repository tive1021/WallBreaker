using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level Instance { get; private set; }
    private int level = 1;
    private int clearCount = 0;
    public float speedMultiplier = 1.2f;
    public GameManager gameManager;
    public BallMovement ballMovement;

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

    public void OnLevelCleared()
    {
        clearCount++;
        level++;
        IncreaseDifficulty();
    }

    private void IncreaseDifficulty()
    {
       
        ballMovement.IncreaseSpeed(speedMultiplier);

        Debug.Log($"Level {level} reached! Clear count: {clearCount}");
    }
}