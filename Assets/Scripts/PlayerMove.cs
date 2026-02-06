using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    Rigidbody2D _rigidbody;
    private float _horizontalDir, _verticalDir;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        _rigidbody.linearVelocity = new Vector2(_horizontalDir, _verticalDir).normalized * speed;
    }

    void OnMoveX(InputValue value)
    {
        var inputVal = value.Get<Vector2>();
        _horizontalDir = inputVal.x;
    }

    void OnMoveY(InputValue value)
    {
        var inputVal = value.Get<Vector2>();
        _verticalDir = inputVal.y;
    }
}
