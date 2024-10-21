using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BottomWall"))
        {
            InfinityModeManager.Instance.GameOver();
        }

        if (DataManager.Instance != null)
        {
            DataManager.Instance.AddScore(1);
        }

        DestroyBrick();
    }

    void DestroyBrick()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            GameManager.Instance.OnBrickDestroyed();  
        }

        Destroy(gameObject);
    }
}
