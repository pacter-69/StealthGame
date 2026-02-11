using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    public float stayTime;
    public float visionRange;
    public float visionAngle;

    private float timer;
    private Transform player;

    public float speed;

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
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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

        animator.transform.position += animator.transform.right.normalized * speed * Time.deltaTime;
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
