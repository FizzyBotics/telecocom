using Pathfinding;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(AIDestinationSetter))]
public class Player : NetworkBehaviour
{
    [SerializeField] private float speed = 5f;
    public Animator animator;
    public AIPath aiPath;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            GameManager.Instance.SetControlledPlayer(this);
        }
        else
        {
            GetComponent<AIDestinationSetter>().enabled = false;
        }
    }

    private void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(speed * Time.deltaTime * aiPath.desiredVelocity.magnitude));

        if (Mathf.Abs(aiPath.desiredVelocity.x) > Mathf.Abs(aiPath.desiredVelocity.y))
        {
            if (aiPath.desiredVelocity.x > 0) { animator.SetTrigger("right"); }
            else { animator.SetTrigger("left"); }
        }
        else
        {
            if (aiPath.desiredVelocity.y > 0) { animator.SetTrigger("back"); }
            else { animator.SetTrigger("front"); }
        }
    }
}

