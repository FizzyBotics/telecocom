using Pathfinding;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private float speed = 5f;
    public AIPath aiPath;

    private void Update()
    {
        //Debug.Log(aiPath.desiredVelocity.magnitude);
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
