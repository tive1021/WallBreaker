using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RetryButton : MonoBehaviour
{
    public void OnRetryButtonClicked()
    {
        DataManager.Instance.UpdateHighScore();  
        StartCoroutine(ReinitializeAfterSceneLoad());
    }

    private IEnumerator ReinitializeAfterSceneLoad()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string nextScene = currentSceneName == "MainScene" ? "MainScene" : "InfinityModeScene";

        SceneManager.LoadScene(nextScene);
        yield return null;  

        if (nextScene == "MainScene" && GameManager.Instance != null)
        {
            GameManager.Instance.InitializeGame();
        }
        else if (nextScene == "InfinityModeScene" && InfinityModeManager.Instance != null)
        {
            InfinityModeManager.Instance.InitializeGame();
        }

        if (DataManager.Instance != null)
        {
            DataManager.Instance.ResetScore();
            DataManager.Instance.ReinitializeInGameUI();
        }
    }
}
