using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    public float stayTime;
    public float visionRange;
    public float visionAngle;

    public float angleToRotate;
    public float rotateDuration;

    private Quaternion startRotation, targetRotation;

    private float timer;
    private Transform player;

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
        targetRotation = startRotation * Quaternion.Euler(0, 0, -180f);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float lerpFactor = Mathf.Clamp01(timer / rotateDuration);

        playerClose = IsPlayerClose(animator.transform);

        if (playerClose)
        {
            playerOnAngle = IsPlayerOnAngle(animator.transform);

            if (playerOnAngle)
            {
                playerAvaliable = IsPlayerAvaliable(animator.transform);
            }
        }

        animator.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, lerpFactor);

        var timeUp = IsTimeUp();

        animator.SetBool("IsChasing", playerClose && playerOnAngle && playerAvaliable);
        animator.SetBool("IsPatroling", timeUp);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerClose = false;
        playerAvaliable = false;
        playerOnAngle = false;
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
