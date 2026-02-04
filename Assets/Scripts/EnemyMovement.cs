using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform EdgedetectionPoint;
    public LayerMask WhatIsWall;
    public float Speed;

    public Vector2 direction = Vector2.right;
    void Update()
    {
        Move();

        if (EdgeDetected()) Flip();
    }

    private void Move()
    {
        transform.Translate(direction * Speed * Time.deltaTime, Space.World);
    }

    private bool EdgeDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.5f, WhatIsWall);

        return (hit.collider == null);
    }

    private void Flip()
    {
        direction = -direction;
        transform.Rotate(0f, 180f, 0f);
    }

}
