using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InfinityModeManager : MonoBehaviour
{
    public static InfinityModeManager Instance { get; private set; }

    public GameObject[] brickPrefabs;
    public GameObject ballPrefab;
    public GameObject gameOverUI;
    private GameObject currentBall;
    public BallMovement ballMovement;
    public GameObject paddle;
    private int ballCount = 1;
    private float spawnTime = 5f; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeGame();
        StartCoroutine(SpawnBrickLineEveryFewSeconds());  
    }

    public void InitializeGame()
    {
        Time.timeScale = 1f;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        if (currentBall != null)
        {
            Destroy(currentBall);
        }

        GenerateInitialWalls();  

        currentBall = Instantiate(ballPrefab, new Vector2(0, -2), Quaternion.identity);
        ballMovement = currentBall.GetComponent<BallMovement>();

        ballCount = 1;
    }

    private void GenerateInitialWalls()
    {
        Vector2 startPosition = new Vector2(-2.5f, 4.1f); 
        int columns = 8;  
        int rows = 5;     

        float xSpacing = 0.7f; 
        float ySpacing = 0.3f;  

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float xPos = startPosition.x + (col * xSpacing);
                float yPos = startPosition.y - (row * ySpacing);
                Vector2 spawnPosition = new Vector2(xPos, yPos);

                int randomIndex = Random.Range(0, brickPrefabs.Length);  
                Instantiate(brickPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            }
        }
    }

    private IEnumerator SpawnBrickLineEveryFewSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);  
            GenerateNewBrickLine();  
            MoveAllBricksDown(); 
        }
    }

    private void GenerateNewBrickLine()
    {
        Vector2 startPosition = new Vector2(-2.5f, 4.1f);
        int columns = 8;
        float xSpacing = 0.7f;

        for (int col = 0; col < columns; col++)
        {
            float xPos = startPosition.x + (col * xSpacing);
            Vector2 spawnPosition = new Vector2(xPos, startPosition.y);
            int randomIndex = Random.Range(0, brickPrefabs.Length);
            Instantiate(brickPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        }
    }

    private void MoveAllBricksDown()
    {
        Brick[] bricks = FindObjectsOfType<Brick>();
        foreach (Brick brick in bricks)
        {
            brick.transform.position += new Vector3(0, -0.3f, 0);  
        }
    }

    public void GameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            DataManager.Instance.ReinitializeSetFalseUI();
        }

        DataManager.Instance.UpdateScoreUI();
        Time.timeScale = 0f;
    }

    public void IncreaseBallCount()
    {
        ballCount++;
    }

    public void DecreaseBallCount()
    {
        ballCount--;
    }

    void Update()
    {
        if (ballCount <= 0)
        {
            GameOver();
        }
    }
}
