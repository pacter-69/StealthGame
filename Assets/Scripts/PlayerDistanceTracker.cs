using System;
using UnityEngine;

public class PlayerDistanceTracker : MonoBehaviour
{
    public static event Action<float> OnMoveUnit;
    private float prevPositionX, prevPositionY;

    void Start()
    {
        prevPositionX = transform.position.x;
        prevPositionY = transform.position.y;
    }

    void Update()
    {
        if (transform.position.x != prevPositionX)
        {
            prevPositionX = transform.position.x;
            OnMoveUnit?.Invoke(Mathf.Abs(transform.position.x - prevPositionX));
        }

        if (transform.position.y != prevPositionY)
        {
            prevPositionY = transform.position.y;
            OnMoveUnit?.Invoke(Mathf.Abs(transform.position.y - prevPositionY));
        }
    }
}
