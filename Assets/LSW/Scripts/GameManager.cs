using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject wallPrefab;
    public GameObject ballPrefab;
    public GameObject gameOverUI;
    private GameObject currentBall;

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

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); 
            DataManager.Instance.ReinitializeGameOverUI();  
            gameOverUI.SetActive(false);  
        }

        Debug.Log("Game objects reinitialized");
    }

    public void OnBrickDestroyed()
    {
        DataManager.Instance.AddScore(1);
        if (FindObjectsOfType<Brick>().Length == 0)
        {
            GameClear();
        }
    }

    public void GameClear()
    {

    }

    public void GameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); 
            DataManager.Instance.ReinitializeGameOverUI();  
        }

        DataManager.Instance.UpdateScoreUI(); 
        Time.timeScale = 0f; 
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

        GenerateWalls();
        currentBall = Instantiate(ballPrefab, new Vector2(0, -2), Quaternion.identity);
    }

    private void GenerateWalls()
    {
        Vector2 startPosition = new Vector2(-2.5f, 4.3f);
        int columns = 9;
        int rows = 5;
        float xSpacing = 0.6f;
        float ySpacing = 0.3f;

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
