using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject wallPrefab; // Wall 프리팹을 설정합니다.
    public Vector2 startPosition = new Vector2(-2.5f, 4.3f); // 첫 생성 위치 설정
    public int columns; // 가로로 생성할 최대 개수 (X 좌표 제한)
    public int rows; // 총 생성할 줄 수
    public float xSpacing; // X축 간격
    public float ySpacing; // Y축 간격

    void Start()
    {
        GenerateWalls();
    }

    void GenerateWalls()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float xPos = startPosition.x + (col * xSpacing);
                if (xPos > 2.5f) // X 좌표가 2.5를 넘어가지 않도록 제한
                    break;

                Vector2 spawnPosition = new Vector2(xPos, startPosition.y - (row * ySpacing));
                Instantiate(wallPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
