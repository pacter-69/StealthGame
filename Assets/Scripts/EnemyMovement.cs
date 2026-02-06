using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform WallDetectionPoint; 
    public LayerMask WhatIsWall;          
    public float Speed = 2f;
    public float CheckDistance = 0.3f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();

        if (WallDetected())
            Flip();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(transform.right.x * Speed, rb.linearVelocity.y);
    }

    private bool WallDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(WallDetectionPoint.position, transform.right, CheckDistance, WhatIsWall);
        return hit.collider != null;
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
}
