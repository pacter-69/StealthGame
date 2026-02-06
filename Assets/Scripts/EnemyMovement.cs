using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform WallDetectionPoint;   // Punto delante del zombi
    public LayerMask WhatIsWall;           // Tu layer "Walls"
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
        return hit.collider != null; // si HAY pared/obstáculo -> flip
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
}
