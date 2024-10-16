using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject wallPrefab; 
    public Vector2 startPosition = new Vector2(-2.5f, 4.3f); 
    public int columns = 9; 
    public int rows = 5; 
    public float xSpacing = 0.6f; 
    public float ySpacing = 0.3f;

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
        GenerateWalls();
    }

    void GenerateWalls()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float xPos = startPosition.x + (col * xSpacing);
                if (xPos > 2.5f) 
                    break;

                Vector2 spawnPosition = new Vector2(xPos, startPosition.y - (row * ySpacing));
                Instantiate(wallPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
