using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class ItemInfo : MonoBehaviour
{
    public enum ItemType { ScaleModifier, BallAdder }
    public ItemType itemType;
    public GameObject ballPrefab;
    public GameObject paddle;

    public Vector2 fixedBallSpawnPosition = new Vector2(0f, 0f); 

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            switch (itemType)
            {
                case ItemType.ScaleModifier:
                    ModifyPaddleScale(other.transform); 
                    break;

                case ItemType.BallAdder:
                    AddBall(); 
                    break;
            }

            Destroy(gameObject); 
        }
    }

    void ModifyPaddleScale(Transform paddle)
    {
        if (paddle != null) 
        {
            Vector3 newScale = paddle.localScale;
            newScale.x *= 1.1f; 
            paddle.localScale = newScale; 

        }
    }

    public void AddBall()
    {
        Instantiate(ballPrefab, fixedBallSpawnPosition, Quaternion.identity);

        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            GameManager.Instance.IncreaseBallCount();
        }
        else if (SceneManager.GetActiveScene().name == "InfinityModeScene")
        {
            InfinityModeManager.Instance.IncreaseBallCount();
        }
    }
}
