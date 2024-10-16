using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string currentScore = "CurrentScore";
    private string highScore = "HighScore";

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(highScore))
        {
            PlayerPrefs.SetInt(highScore, 0);
        }
        PlayerPrefs.SetInt(currentScore, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
