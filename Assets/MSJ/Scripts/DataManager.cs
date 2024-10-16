using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }

    public Text CurrentScoreTextInGame;
    public Text HighScoreTextInGame;
    public Text CurrentScoreTextGameOver;
    public Text HighScoreTextGameOver;

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

    void Start()
    {
        LoadHighScore();  
        ReinitializeInGameUI();  
        UpdateScoreUI();
    }

    public void AddScore(int score)
    {
        CurrentScore += score;
        UpdateHighScore();
        UpdateScoreUI();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        UpdateScoreUI();
    }

    public void UpdateHighScore()
    {
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
        }
    }

    public void LoadHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void UpdateScoreUI()
    {
        if (CurrentScoreTextInGame != null)
            CurrentScoreTextInGame.text = CurrentScore.ToString();

        if (HighScoreTextInGame != null)
            HighScoreTextInGame.text = HighScore.ToString();

        if (CurrentScoreTextGameOver != null)
            CurrentScoreTextGameOver.text = CurrentScore.ToString();

        if (HighScoreTextGameOver != null)
            HighScoreTextGameOver.text = HighScore.ToString();
    }

    public void ReinitializeInGameUI()
    {
        CurrentScoreTextInGame = GameObject.Find("BackGround/Canvas/Score/CurrentScoreTextInGame")?.GetComponent<Text>();
        HighScoreTextInGame = GameObject.Find("BackGround/Canvas/HighScoreText/HighScoreTextInGame")?.GetComponent<Text>();
    }

    public void ReinitializeGameOverUI()
    {
        CurrentScoreTextGameOver = GameObject.Find("GameOverUI/Canvas/CurrentScoreTextUI/CurrentScoreTextGameOver")?.GetComponent<Text>();
        HighScoreTextGameOver = GameObject.Find("GameOverUI/Canvas/HighScoreTextUI/HighScoreTextGameOver")?.GetComponent<Text>();
    }
}
