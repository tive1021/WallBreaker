using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    float x = 0;

    private Rigidbody2D move_rb;
    private Vector3 paddle_pos;


    private void Start()
    {
        paddle_pos = transform.position;
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        PaddleMove();
    }

    private void PaddleMove()
    {
        paddle_pos.x += x * moveSpeed * Time.deltaTime;
        paddle_pos.x = Mathf.Clamp(paddle_pos.x, -3f, 3f);
        transform.position = paddle_pos;    
    }
}
