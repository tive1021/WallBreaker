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
        SceneManager.LoadScene("MainScene");
        yield return null; 

        if (GameManager.Instance != null)
        {
            GameManager.Instance.InitializeGame();
        }

        if (DataManager.Instance != null)
        {
            DataManager.Instance.ResetScore();  
            DataManager.Instance.ReinitializeInGameUI();  
        }
    }

    
}
