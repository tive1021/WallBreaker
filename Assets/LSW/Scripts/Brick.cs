using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DataManager.Instance != null)
        {
            DataManager.Instance.AddScore(1); // 점수 1점 추가
        }
        DestroyBrick();
    }

    void DestroyBrick()
    {
        Destroy(gameObject);
    }
}
