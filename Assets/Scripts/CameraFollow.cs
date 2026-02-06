using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float leftXLimit, rightXLimit;

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(leftXLimit, target.position.x, rightXLimit), -1, transform.position.z);
    }
}
