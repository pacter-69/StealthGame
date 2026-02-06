using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class ChaseBehaviour : MonoBehaviour
{
    [SerializeField]
    private float distance;

    public float speed = 2;
    public float visionRange;
    public bool isPlayerClose { get; private set; }

    private Transform player;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isPlayerClose = IsPlayerClose(transform);
    }

    private bool IsPlayerClose(Transform transform)
    {
        var dist = Vector3.Distance(transform.position, player.position);
        distance = dist;
        return (dist < visionRange);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
