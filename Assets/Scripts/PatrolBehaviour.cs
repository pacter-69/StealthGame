using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    public float stayTime;
    public float visionRange;
    public float visionAngle;

    private float timer;
    private Transform player;
    private Vector2 targetPos;

    private float targetFactor;

    [SerializeField]
    private bool playerClose;
    [SerializeField]
    private bool playerOnAngle;
    [SerializeField]
    private bool playerAvaliable;

    // OnStateEnter is called when a transition starts and
    // the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0.0f;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        targetPos = new Vector2(animator.transform.right.x, animator.transform.position.y);
    }

    // OnStateUpdate is called on each Update frame between
    // OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check triggers
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

        animator.SetBool("IsChasing", playerClose && playerOnAngle && playerAvaliable);
        animator.SetBool("IsPatroling", !timeUp);

        //animator.transform.position = Vector2.Lerp(animator.transform.position, targetPos, timer / stayTime);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerClose = false;
        playerAvaliable = false;
        playerOnAngle = false;
        targetFactor *= -1;
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
