using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextUI : MonoBehaviour
{
    // ���� ���� �� ������ ����
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    // ���� ���� �߿� ���� ����
    [SerializeField] private TextMeshProUGUI progressScoreText;
    [SerializeField] private TextMeshProUGUI mainSceneHighScoreText;

    public void Start()
    {

    }

    public void DisplayerScore()
    {
        currentScoreText.text = $"{GetCureentScore()}";
        highScoreText.text = $"{GetHighScore()}";
        mainSceneHighScoreText.text = $"{GetHighScore()}";
    }
    public void Update()
    {
        progressScoreText.text = $"Score : {GetCureentScore()}";
        mainSceneHighScoreText.text = $"{GetHighScore()}";
    }

    public int GetCureentScore()
    {
        return DataManager.dataManager.currentScore;
    }

    public int GetHighScore()
    {
        return DataManager.dataManager.highScore;
    }
}
