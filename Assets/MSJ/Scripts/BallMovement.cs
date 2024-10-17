using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    void Start()
    {
        _rb2d.velocity = direction * speed;
    }

    void FixedUpdate()
    {
    //    if (_rb2d != null)  
    //    {
    //        _rb2d.velocity = direction * speed;
    //    }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BottomWall"))
        {
            Destroy(gameObject);
            GameManager.Instance.DecreaseBallCount();
        }

        Vector2 collisionNormal = collision.contacts[0].normal;

        Vector2 reflectedDirection = Vector2.Reflect(direction, collisionNormal).normalized;

        float horizontalAngle = Vector2.Angle(reflectedDirection, Vector2.up);

        if (horizontalAngle > 60f && horizontalAngle < 90f)
        {
            float sign = Mathf.Sign(reflectedDirection.y);
            float angleInRadians = Mathf.Deg2Rad * 30f;
            reflectedDirection = new Vector2(reflectedDirection.x, Mathf.Sin(angleInRadians) * sign).normalized;
        }

        direction = reflectedDirection;
        _rb2d.velocity = direction * speed;

        //direction = Vector2.Reflect(direction, collisionNormal).normalized;

        //if (Mathf.Abs(collisionNormal.y) > Mathf.Abs(collisionNormal.x))
        //{
        //    direction.y = -direction.y;
        //    //Debug.Log($"{gameObject.GetInstanceID()}, {direction}");
        //    //Debug.Break();
        //    _rb2d.MovePosition(collision.contacts[0].point);

        //}
        //else if (Mathf.Abs(collisionNormal.x) > Mathf.Abs(collisionNormal.y))
        //{
        //    direction.x = -direction.x;
        //    //Debug.Log($"{gameObject.GetInstanceID()}, {direction}");
        //    _rb2d.MovePosition(collision.contacts[0].point);
        //}
        

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
