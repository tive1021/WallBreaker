using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject[] brickPrefabs;  
    public GameObject ballPrefab;
    public GameObject gameOverUI;
    public GameObject stageClearUI;
    private GameObject currentBall;
    public BallMovement ballMovement;
    public Button nextStageButton;
    public GameObject paddle;
    public Vector3 paddleInitialScale = new Vector3(1.4f, 1.4f, 1f);


    private int brickCount;
    public int currentLevel = 1;
    private int ballCount = 1;


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
        ReinitializeGameObjects();
        InitializeGame();
    }

    public void ReinitializeGameObjects()
    {
        gameOverUI = GameObject.Find("GameOverUI");
        stageClearUI = GameObject.Find("StageClearUI");

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            DataManager.Instance.ReinitializeSetFalseUI();
            gameOverUI.SetActive(false);
        }

        if (stageClearUI != null)
        {
            stageClearUI.SetActive(true);
            DataManager.Instance.ReinitializeSetFalseUI();
            stageClearUI.SetActive(false);
        }
    }

    public void OnBrickDestroyed()
    {
        brickCount--;

        if (brickCount <= 0)
        {
            GameClear();
        }
    }

    public void GameClear()
    {
        if (stageClearUI != null)
        {
            stageClearUI.SetActive(true);
            DataManager.Instance.ReinitializeSetFalseUI();
        }

        DataManager.Instance.UpdateScoreUI();
        Time.timeScale = 0f;
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

    public void InitializeGame()
    {

        float randomX = Random.Range(-2.5f, 2.5f);
        Time.timeScale = 1f;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        if (currentBall != null)
        {
            Destroy(currentBall);
        }

        if (stageClearUI != null)
        {
            stageClearUI.SetActive(false);
        }

        GenerateWalls(currentLevel);  
        brickCount = FindObjectsOfType<Brick>().Length;

        currentBall = Instantiate(ballPrefab, new Vector2(randomX, -2), Quaternion.identity);
        ballMovement = currentBall.GetComponent<BallMovement>(); 

        ballCount = 1;
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

    public void OnNextStageButtonClicked()
    {
        currentLevel++;  
        LevelUI.Instance.UpdateLevelUI(currentLevel);

        RemoveAllBalls();
        ResetPaddleSize();
        InitializeGame();

        if (ballMovement != null)
        {
            ballMovement.IncreaseSpeed(1.2f); 
        }
    }

    private void RemoveAllBalls()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
    }

    private void ResetPaddleSize()
    {
        if (paddle != null)
        {
            paddle.transform.localScale = paddleInitialScale; 
        }
    }
    private void GenerateWalls(int level)
    {
        Vector2 startPosition = new Vector2(-2.5f, 4.1f);
        int columns = 9; 
        int rows = 5 + (level - 1);  
        float xSpacing = 0.7f;
        float ySpacing = 0.3f;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float xPos = startPosition.x + (col * xSpacing);
                if (xPos > 2.5f)
                    break;

                Vector2 spawnPosition = new Vector2(xPos, startPosition.y - (row * ySpacing));

                int randomIndex = Random.Range(0, brickPrefabs.Length);  
                Instantiate(brickPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            }
        }
    }
}
