using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class ChaseBehaviour : MonoBehaviour
{
    [SerializeField]
    private float distance;

    public float visionRange;
    public float visionAngle;

    public bool isPlayerClose;
    public bool isPlayerOnAngle;
    public float angle;

    private Transform player;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isPlayerClose = IsPlayerClose(transform);

        if (isPlayerClose) isPlayerOnAngle = IsPlayerOnAngle(transform);
        else isPlayerOnAngle = false;
    }

    private bool IsPlayerClose(Transform transform)
    {
        var dist = Vector3.Distance(transform.position, player.position);
        distance = dist;
        return (dist < visionRange);
    }

    private bool IsPlayerOnAngle(Transform transform)
    {
        return Vector2.Angle(transform.right, player.position - transform.position) < visionAngle;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, visionRange);
        Gizmos.DrawRay(transform.position, Quaternion.AngleAxis(visionAngle, transform.forward) * transform.right * visionRange);
        Gizmos.DrawRay(transform.position, Quaternion.AngleAxis(-visionAngle, transform.forward) * transform.right * visionRange);
        if(player != null) Gizmos.DrawLine(transform.position, player.position);
    }
}
