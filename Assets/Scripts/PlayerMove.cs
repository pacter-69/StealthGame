using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    Rigidbody2D _rigidbody;
    private float _horizontalDir, _verticalDir; // Horizontal move direction value [-1, 1]

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        _rigidbody.linearVelocity = new Vector2(_horizontalDir, _verticalDir).normalized * speed;
    }

    // NOTE: InputSystem: "move" action becomes "OnMove" method
    void OnMoveX(InputValue value)
    {
        // Read value from control, the type depends on what
        // type of controls the action is bound to
        var inputVal = value.Get<Vector2>();
        _horizontalDir = inputVal.x;
    }

    void OnMoveY(InputValue value)
    {
        // Read value from control, the type depends on what
        // type of controls the action is bound to
        var inputVal = value.Get<Vector2>();
        _verticalDir = inputVal.y;
    }
}
