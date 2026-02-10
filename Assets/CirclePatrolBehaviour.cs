using UnityEngine;

public class CirclePatrolBehaviour : StateMachineBehaviour
{
    public float stayTime;
    public float visionRange;
    public float visionAngle;

    private float timer;
    private Transform player;
    [SerializeField]
    private Vector3 vectorToRotate;

    public float speed;

    private Quaternion startRotation, targetRotation;

    [SerializeField]
    private bool playerClose;
    [SerializeField]
    private bool playerOnAngle;
    [SerializeField]
    private bool playerAvaliable;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0.0f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startRotation = animator.transform.rotation;
        targetRotation = startRotation * Quaternion.Euler(0, 0, animator.gameObject.GetComponent<CircleEnemyAngle>().angle);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float lerpFactor = Mathf.Clamp01(timer / stayTime);

        playerClose = IsPlayerClose(animator.transform);

        if (playerClose)
        {
            playerOnAngle = IsPlayerOnAngle(animator.transform);

            if (playerOnAngle)
            {
                playerAvaliable = IsPlayerAvaliable(animator.transform);
            }
        }

        var timeUp = IsTimeUp();

        animator.SetBool("isChasing", playerClose && playerOnAngle && playerAvaliable);
        animator.SetBool("isPatroling", !timeUp);

        vectorToRotate = animator.transform.right.normalized;

        animator.transform.position += vectorToRotate * speed * Time.deltaTime;
        animator.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, lerpFactor);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerClose = false;
        playerAvaliable = false;
        playerOnAngle = false;
        animator.gameObject.GetComponent<CircleEnemyAngle>().angle *= -1;
    }

    private bool IsTimeUp()
    {
        timer += Time.deltaTime;
        return (timer > stayTime);
    }

    private bool IsPlayerClose(Transform transform)
    {
        var dist = Vector3.Distance(transform.position, player.position);
        return (dist < visionRange);
    }

    private bool IsPlayerOnAngle(Transform transform)
    {
        return Vector2.Angle(transform.right, player.position - transform.position) < visionAngle;
    }

    private bool IsPlayerAvaliable(Transform transform)
    {
        Vector2 vectorToPlayer = player.position - transform.position;
        GameObject playerHit = Physics2D.Raycast(transform.position, vectorToPlayer).collider.gameObject;
        return playerHit.CompareTag("Player");
    }
}
