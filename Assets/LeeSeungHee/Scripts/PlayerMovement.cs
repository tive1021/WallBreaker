using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D move_rb;

    private float moveDirection;


    private void Start()
    {
        move_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDirection = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection = moveSpeed  * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection = moveSpeed * Time.deltaTime ;
        }
        this.transform.Translate(new Vector3(moveDirection,0,0));   
    }

    private void Move()
    {
        move_rb.velocity = new Vector2(moveDirection * moveSpeed, move_rb.velocity.y);
    }
}
