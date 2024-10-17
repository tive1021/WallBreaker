using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    [SerializeField] private float speed = 1f;
    private Vector2 direction = new Vector2(1, 1).normalized;

    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_rb2d != null)  
        {
            _rb2d.velocity = direction * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BottomWall"))
        {
            Destroy(gameObject);
            GameManager.Instance.DecreaseBallCount();
        }

        Vector2 collisionNormal = collision.contacts[0].normal;

        if (Mathf.Abs(collisionNormal.y) > Mathf.Abs(collisionNormal.x))
        {
            direction.y = -direction.y;
        }
        else if (Mathf.Abs(collisionNormal.x) > Mathf.Abs(collisionNormal.y))
        {
            direction.x = -direction.x;
        }

        if (collision.gameObject.CompareTag("Brick"))
        {
            SoundManager.Instance.BrickPop();
        }
        else
        {
            SoundManager.Instance.BallPop();
        }
    }

    public void IncreaseSpeed(float multiplier)
    {
        speed *= multiplier;

        if (_rb2d != null)
        {
            _rb2d.velocity = direction * speed;
        }
    }
}
