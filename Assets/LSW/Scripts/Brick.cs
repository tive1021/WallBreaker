using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DataManager.Instance != null)
        {
            DataManager.Instance.AddScore(1);
        }

        DestroyBrick();
    }

    void DestroyBrick()
    {
        GameManager.Instance.OnBrickDestroyed();
        Destroy(gameObject);
    }
}
