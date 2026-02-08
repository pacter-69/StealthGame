using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    public float stayTime;
    public float visionRange;
    public float visionAngle;

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
    }

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
        animator.SetBool("IsPatroling", timeUp);

        // Move
        //animator.transform.position = Vector2.Lerp(startPos, targetPos, timer / stayTime);
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
        Debug.Log(playerHit.name);
        return playerHit.CompareTag("Player");
    }
}
