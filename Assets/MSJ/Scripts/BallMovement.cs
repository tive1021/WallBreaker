using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    [SerializeField] private float speed = 1f;
    private Vector2 direction = new Vector2(1, 1).normalized;


    // Start is called before the first frame update
    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb2d.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ����: ���� �浹�ϸ� �ݴ� �������� �̵�
        if (collision.gameObject.CompareTag("Brick"))
        {
            direction = -direction;  // ���� ����
        }
    }


}
