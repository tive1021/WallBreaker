using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI progressScoreText;

    public void Start()
    {
        currentScoreText.text = $"{GetCureentScore()}";
        highScoreText.text = $"{GetHighScore()}";
    }
    public void Update()
    {
        progressScoreText.text = $"Score : {GetCureentScore()}";
    }

    public int GetCureentScore()
    {
        return DataManager.dataManager.currentScore;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(nameof(DataManager.dataManager.highScore), 
            DataManager.dataManager.currentScore);
    }





}
