using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager dataManager { get; private set; }
    public int currentScore = 10;
    public int highScore { get; private set; }

    private void Awake()
    {
        if (dataManager == null)
        {
            dataManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(nameof(highScore)))
        {
            PlayerPrefs.SetInt(nameof(highScore), 0);
        }
        else
        {
            highScore = PlayerPrefs.GetInt(nameof(highScore));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScore > highScore)
        {
            PlayerPrefs.SetInt(nameof(highScore), currentScore);
            highScore = currentScore;
        }
    }
}
