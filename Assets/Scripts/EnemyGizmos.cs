using UnityEngine;

public class EnemyGizmos : MonoBehaviour
{
    private GameObject player;
    public float visionRange;
    public float visionAngle;

    public GameObject alarm;

    private void Start()
    {
        player = GameObject.Find("Player");   
    }

    private void Update()
    {
        alarm.SetActive(GetComponent<Animator>().GetBool("isChasing"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, visionRange);
        Gizmos.DrawRay(transform.position, Quaternion.AngleAxis(visionAngle, transform.forward) * transform.right * visionRange);
        Gizmos.DrawRay(transform.position, Quaternion.AngleAxis(-visionAngle, transform.forward) * transform.right * visionRange);
        if (player != null) Gizmos.DrawLine(transform.position, player.transform.position);
    }
}
