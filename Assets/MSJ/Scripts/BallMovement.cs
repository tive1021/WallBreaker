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
    private bool isCollider = false;


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
        Vector2 collisionNormal = collision.contacts[0].normal;

        // ���� �浹 (���� �Ǵ� �Ʒ��� �浹)
        if (Mathf.Abs(collisionNormal.y) > Mathf.Abs(collisionNormal.x))
        {
            direction.y = -direction.y;  // y�� ���� (���� ����)
        }
        // ���� �浹 (���� �Ǵ� ������ �浹)
        else if (Mathf.Abs(collisionNormal.x) > Mathf.Abs(collisionNormal.y))
        {
            direction.x = -direction.x;  // x�� ���� (���� ����)
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    }


}
