using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    Rigidbody2D body;
    private float horizontalDir, verticalDir;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = body.linearVelocity;
        body.linearVelocity = new Vector2(horizontalDir, verticalDir).normalized * speed;
    }

    void OnMoveX(InputValue value)
    {
        var inputVal = value.Get<Vector2>();
        horizontalDir = inputVal.x;
    }

    void OnMoveY(InputValue value)
    {
        var inputVal = value.Get<Vector2>();
        verticalDir = inputVal.y;
    }
}
