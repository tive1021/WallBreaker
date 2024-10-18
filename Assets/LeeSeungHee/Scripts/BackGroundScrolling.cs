using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    float viewHeight;
    float viewWidth;

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2;
        viewWidth = viewHeight * Camera.main.aspect + 1;
    }

    private void Update()
    {
        Time.timeScale = 1f;
        Scrolling();
    }

    public void Scrolling()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.left * speed * Time.deltaTime;
        transform.position = curPos + nextPos;

        if (sprites[endIndex].position.x < viewWidth * (-1))
        {
            Vector3 backSpritePos = sprites[startIndex].position;
            Vector3 frontSpritePos = sprites[endIndex].position;

            sprites[endIndex].transform.position = backSpritePos + Vector3.right * viewWidth;

            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = startIndexSave;

        }

    }
}
