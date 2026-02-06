using System;
using UnityEngine;

public class PlayerDistanceTracker : MonoBehaviour
{
    public static event Action<float> OnMoveUnit;
    private float prevPositionX, prevPositionY;
    private float distanceX, distanceY;
    private float counter;

    void Start()
    {
        prevPositionX = transform.position.x;
        prevPositionY = transform.position.y;
    }

    void Update()
    {
        counter += Time.deltaTime;

        distanceX += Mathf.Abs(transform.position.x - prevPositionX);
        prevPositionX = transform.position.x;

        distanceY += Mathf.Abs(transform.position.y - prevPositionY);
        prevPositionY = transform.position.y;

        if (counter >= 0.1f)
        {
            OnMoveUnit?.Invoke(distanceX);
            OnMoveUnit?.Invoke(distanceY);
            distanceX = 0;
            distanceY = 0;

            counter = 0;
        }
    }
}
