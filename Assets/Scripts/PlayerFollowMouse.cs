using UnityEngine;

public class PlayerFollowMouse : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.FromToRotation(Vector2.right, (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position));
    }
}
