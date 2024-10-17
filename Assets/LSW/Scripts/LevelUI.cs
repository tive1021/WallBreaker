using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public static LevelUI Instance { get; private set; }
    public Text levelText;

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

    public void UpdateLevelUI(int currentLevel)
    {
        if (levelText != null)
        {
            levelText.text = "" + currentLevel.ToString();
        }
    }
}