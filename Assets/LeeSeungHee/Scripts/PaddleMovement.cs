
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D move_rb;

    private float moveDirection;

    private void Start()
    {
        move_rb = GetComponent<Rigidbody2D>();
        move_rb.gravityScale = 0; 
        move_rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY; 
    }

    private void Update()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        move_rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
    }
}
